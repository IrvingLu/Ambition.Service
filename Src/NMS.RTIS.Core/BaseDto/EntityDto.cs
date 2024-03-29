﻿/**********************************************************************
* 命名空间：NMS.RTIS.Core.BaseDto
*
* 功  能：实体传输对象
* 类  名：EntityDto
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System;

namespace NMS.RTIS.Core.BaseDto
{
    public class EntityDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 数据版本
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
