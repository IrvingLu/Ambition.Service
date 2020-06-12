using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Infrastructure.Migrations
{
    public partial class _1754 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModifyCount",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyUser",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    ProjectCode = table.Column<string>(nullable: true),
                    Delegater = table.Column<string>(nullable: true),
                    ProjectType = table.Column<int>(nullable: false),
                    ProjectArea = table.Column<string>(nullable: true),
                    Department = table.Column<int>(nullable: false),
                    District = table.Column<int>(nullable: false),
                    DocumentCode = table.Column<string>(nullable: true),
                    DocumentName = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    Handed = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Handover = table.Column<DateTime>(nullable: false),
                    Attachment = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    ConsultTime = table.Column<DateTime>(nullable: false),
                    SecretLevel = table.Column<int>(nullable: false),
                    IsCopy = table.Column<bool>(nullable: false),
                    IsTake = table.Column<bool>(nullable: false),
                    BackTime = table.Column<DateTime>(nullable: false),
                    CopyNum = table.Column<int>(nullable: false),
                    ConsultContent = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentApply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    LeaveTime = table.Column<DateTime>(nullable: false),
                    LeaveContent = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMain",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    PersonInCharge = table.Column<string>(nullable: true),
                    ProjectState = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reimbursement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProduceTime = table.Column<DateTime>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Money = table.Column<decimal>(nullable: false),
                    Voucher = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reimbursement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    AmountArrears = table.Column<decimal>(nullable: false),
                    LoanPeriod = table.Column<DateTime>(nullable: false),
                    RepaymentType = table.Column<int>(nullable: false),
                    RepaymentPeriod = table.Column<int>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    InterestPerPeriod = table.Column<decimal>(nullable: false),
                    RepaymentAccount = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    OpeningBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewProcess",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    AuditType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProcess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    SealName = table.Column<string>(nullable: true),
                    SealPurpose = table.Column<string>(nullable: true),
                    SealState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SealApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    SealType = table.Column<int>(nullable: false),
                    TakeOut = table.Column<bool>(nullable: false),
                    BackTime = table.Column<DateTime>(nullable: false),
                    SealExplain = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SealApply", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashArrears",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    EntrustingParty = table.Column<string>(nullable: true),
                    ProjectType = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdCard = table.Column<string>(nullable: true),
                    IdCardPhotoFront = table.Column<string>(nullable: true),
                    IdCardPhotoNegative = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    BankArrears = table.Column<bool>(nullable: false),
                    AmountArrears = table.Column<decimal>(nullable: true),
                    RepaymentPlanId = table.Column<Guid>(nullable: true),
                    Guarantee = table.Column<string>(nullable: true),
                    GuaranteePhone = table.Column<string>(nullable: true),
                    GuaranteeIdCard = table.Column<string>(nullable: true),
                    GuaranteeIdCardPhotoFront = table.Column<string>(nullable: true),
                    GuaranteeIdCardPhotoNegative = table.Column<string>(nullable: true),
                    GuaranteeAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashArrears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashArrears_RepaymentPlan_RepaymentPlanId",
                        column: x => x.RepaymentPlanId,
                        principalTable: "RepaymentPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebtPaying",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    EntrustingParty = table.Column<string>(nullable: true),
                    ProjectType = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdCard = table.Column<string>(nullable: true),
                    IdCardPhotoFront = table.Column<string>(nullable: true),
                    IdCardPhotoNegative = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    BankArrears = table.Column<bool>(nullable: false),
                    AmountArrears = table.Column<decimal>(nullable: true),
                    RepaymentPlanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtPaying", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtPaying_RepaymentPlan_RepaymentPlanId",
                        column: x => x.RepaymentPlanId,
                        principalTable: "RepaymentPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mortgage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    EntrustingParty = table.Column<string>(nullable: true),
                    ProjectType = table.Column<int>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IdCard = table.Column<string>(nullable: true),
                    IdCardPhotoFront = table.Column<string>(nullable: true),
                    IdCardPhotoNegative = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    BankArrears = table.Column<bool>(nullable: false),
                    AmountArrears = table.Column<decimal>(nullable: true),
                    RepaymentPlanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mortgage_RepaymentPlan_RepaymentPlanId",
                        column: x => x.RepaymentPlanId,
                        principalTable: "RepaymentPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    AuditState = table.Column<int>(nullable: false),
                    PersionAudit = table.Column<string>(nullable: true),
                    AuditTime = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    ProjectMainId = table.Column<Guid>(nullable: true),
                    ReviewProcessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audit_ProjectMain_ProjectMainId",
                        column: x => x.ProjectMainId,
                        principalTable: "ProjectMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_ReviewProcess_ReviewProcessId",
                        column: x => x.ReviewProcessId,
                        principalTable: "ReviewProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DebtRepaymentInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    HousingSituation = table.Column<int>(nullable: false),
                    HousingType = table.Column<int>(nullable: false),
                    RealEstateUse = table.Column<int>(nullable: false),
                    HousingAddress = table.Column<string>(nullable: true),
                    BuiltUpArea = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Orientation = table.Column<string>(nullable: true),
                    TotalLayerNumber = table.Column<string>(nullable: true),
                    OriginalPurchaseInvoiceAmount = table.Column<decimal>(nullable: false),
                    OriginalDeedTaxAmount = table.Column<decimal>(nullable: false),
                    RealEstateCertificate = table.Column<string>(nullable: true),
                    TaxCollection = table.Column<string>(nullable: true),
                    HousePlan = table.Column<string>(nullable: true),
                    EstimatedSalesTax = table.Column<decimal>(nullable: false),
                    HousingAppraisalAmount = table.Column<decimal>(nullable: false),
                    EstimatedAssessmentCost = table.Column<decimal>(nullable: false),
                    ActualAssessmentCost = table.Column<decimal>(nullable: false),
                    HousingAppraisalReport = table.Column<string>(nullable: true),
                    LegalInstrument = table.Column<string>(nullable: true),
                    Contract = table.Column<string>(nullable: true),
                    RepaymentTime = table.Column<DateTime>(nullable: false),
                    RepaymentPrice = table.Column<decimal>(nullable: false),
                    DebtPayingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtRepaymentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtRepaymentInformation_DebtPaying_DebtPayingId",
                        column: x => x.DebtPayingId,
                        principalTable: "DebtPaying",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollateralInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    HousingSituation = table.Column<int>(nullable: false),
                    HousingType = table.Column<int>(nullable: false),
                    RealEstateUse = table.Column<int>(nullable: false),
                    HousingAddress = table.Column<string>(nullable: true),
                    BuiltUpArea = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: true),
                    Orientation = table.Column<string>(nullable: true),
                    TotalLayerNumber = table.Column<string>(nullable: true),
                    OriginalPurchaseInvoiceAmount = table.Column<decimal>(nullable: false),
                    OriginalDeedTaxAmount = table.Column<decimal>(nullable: false),
                    RealEstateCertificate = table.Column<string>(nullable: true),
                    TaxCollection = table.Column<string>(nullable: true),
                    HousePlan = table.Column<string>(nullable: true),
                    EstimatedSalesTax = table.Column<decimal>(nullable: false),
                    HousingAppraisalAmount = table.Column<decimal>(nullable: false),
                    EstimatedAssessmentCost = table.Column<decimal>(nullable: false),
                    ActualAssessmentCost = table.Column<decimal>(nullable: false),
                    HousingAppraisalReport = table.Column<string>(nullable: true),
                    LegalInstrument = table.Column<string>(nullable: true),
                    Contract = table.Column<string>(nullable: true),
                    Mortgagor = table.Column<string>(nullable: true),
                    MortgageHolder = table.Column<string>(nullable: true),
                    Guarantee = table.Column<string>(nullable: true),
                    MortgageTime = table.Column<DateTime>(nullable: false),
                    MortgagePrice = table.Column<decimal>(nullable: false),
                    MortgageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollateralInformation_Mortgage_MortgageId",
                        column: x => x.MortgageId,
                        principalTable: "Mortgage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enclosure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ContractScanning = table.Column<string>(nullable: true),
                    LegalInstrument = table.Column<string>(nullable: true),
                    CashArrearsId = table.Column<Guid>(nullable: true),
                    DebtPayingId = table.Column<Guid>(nullable: true),
                    MortgageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enclosure_CashArrears_CashArrearsId",
                        column: x => x.CashArrearsId,
                        principalTable: "CashArrears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enclosure_DebtPaying_DebtPayingId",
                        column: x => x.DebtPayingId,
                        principalTable: "DebtPaying",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enclosure_Mortgage_MortgageId",
                        column: x => x.MortgageId,
                        principalTable: "Mortgage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receivables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifyUser = table.Column<string>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    ModifyCount = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    CollectionAccount = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    OpeningBank = table.Column<string>(nullable: true),
                    CashArrearsId = table.Column<Guid>(nullable: true),
                    DebtPayingId = table.Column<Guid>(nullable: true),
                    MortgageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivables_CashArrears_CashArrearsId",
                        column: x => x.CashArrearsId,
                        principalTable: "CashArrears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receivables_DebtPaying_DebtPayingId",
                        column: x => x.DebtPayingId,
                        principalTable: "DebtPaying",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receivables_Mortgage_MortgageId",
                        column: x => x.MortgageId,
                        principalTable: "Mortgage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ProjectMainId",
                table: "Audit",
                column: "ProjectMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_ReviewProcessId",
                table: "Audit",
                column: "ReviewProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CashArrears_RepaymentPlanId",
                table: "CashArrears",
                column: "RepaymentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CollateralInformation_MortgageId",
                table: "CollateralInformation",
                column: "MortgageId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtPaying_RepaymentPlanId",
                table: "DebtPaying",
                column: "RepaymentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtRepaymentInformation_DebtPayingId",
                table: "DebtRepaymentInformation",
                column: "DebtPayingId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosure_CashArrearsId",
                table: "Enclosure",
                column: "CashArrearsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosure_DebtPayingId",
                table: "Enclosure",
                column: "DebtPayingId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosure_MortgageId",
                table: "Enclosure",
                column: "MortgageId");

            migrationBuilder.CreateIndex(
                name: "IX_Mortgage_RepaymentPlanId",
                table: "Mortgage",
                column: "RepaymentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_CashArrearsId",
                table: "Receivables",
                column: "CashArrearsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_DebtPayingId",
                table: "Receivables",
                column: "DebtPayingId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_MortgageId",
                table: "Receivables",
                column: "MortgageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "CollateralInformation");

            migrationBuilder.DropTable(
                name: "DebtRepaymentInformation");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "DocumentApply");

            migrationBuilder.DropTable(
                name: "Enclosure");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "Receivables");

            migrationBuilder.DropTable(
                name: "Reimbursement");

            migrationBuilder.DropTable(
                name: "Seal");

            migrationBuilder.DropTable(
                name: "SealApply");

            migrationBuilder.DropTable(
                name: "ProjectMain");

            migrationBuilder.DropTable(
                name: "ReviewProcess");

            migrationBuilder.DropTable(
                name: "CashArrears");

            migrationBuilder.DropTable(
                name: "DebtPaying");

            migrationBuilder.DropTable(
                name: "Mortgage");

            migrationBuilder.DropTable(
                name: "RepaymentPlan");

            migrationBuilder.DropColumn(
                name: "ModifyCount",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ModifyUser",
                table: "Customer");
        }
    }
}
