/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient
*
* 功  能：患者逻辑类（post）
* 类  名：PatientCommandHandler
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Infrastructure.Repositories;
using NMS.RTIS.Service.Patient.Command;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Service.Patient
{
    public class PatientCommandHandler : IRequestHandler<CreatePatientCommand, Unit>, IRequestHandler<UpdatePatientCommand, Unit>, IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IRepository<Domain.Patient.Patient> _patientRepository;

        public PatientCommandHandler(IRepository<Domain.Patient.Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var data = new Domain.Patient.Patient(request.Name);
            await _patientRepository.AddAsync(data);
            await _patientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return new Unit();
        }
        /// <summary>
        /// 更新患者信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var data = await _patientRepository.TableNoTracking.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
            data.Name = request.Name;
            await _patientRepository.UpdateAsync(data);
            await _patientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return new Unit();
        }
        /// <summary>
        /// 删除患者信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _patientRepository.SoftDeleteAsync(request.Id);
            await _patientRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return new Unit();
        }
    }
}
