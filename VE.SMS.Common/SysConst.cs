using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.Common
{
    public static class FooterConsts
    {
        public const string Enquiry = "咨询单页尾";
        public const string Quotation = "报价单页尾";
        public const string Order = "订单页尾";
        public const string Delivery = "送货安装单页尾";
    }
    public static class ACLConsts
    {
        public const string ViewAccessControlManagement = "查看权限管理页面";
        public const string ViewDeliveryForm = "查看送货安装单";
        public const string ViewDeliveryList = "查看送货安装单列表";
        public const string ViewEnquiryForm = "查看咨询单";
        public const string ViewEnquiryList = "查看咨询单列表";
        public const string ViewMachiningForm = "查看生产单";
        public const string ViewMachiningList = "查看生产单列表";
        public const string ViewOrderForm = "查看订单";
        public const string ViewOrderList = "查看订单列表";
        public const string ViewProductForm = "查看产品";
        public const string ViewProductList = "查看产品列表";
        public const string ViewPurchaseForm = "查看采购单";
        public const string ViewPurchaseList = "查看采购单列表";
        public const string ViewQuotationForm = "查看报价单";
        public const string ViewQuotationList = "查看报价单列表";
        public const string ViewRefineForm = "查看细化单";
        public const string ViewRefineList = "查看细化单列表";
        public const string ViewSettlementForm = "查看送货安装单";
        public const string ViewSettlementList = "查看结算单列表";
        public const string ViewSurveyForm = "查看测量单";
        public const string ViewSurveyList = "查看测量单列表";
        public const string ViewSystemConfiguration = "查看系统配置";

        public const string ViewOrdListContractAmount = "查看订单汇总合同金额";
        public const string ViewOrdListSettlementAmount = "查看订单汇总结算金额";
        public const string ViewOrdListTotalReceivedAmount = "查看订单汇总累积已收";
        public const string ViewOrdListTotalNeedAmount = "查看订单汇总累计应收";
        public const string ViewOrdUnitPirce = "查看订单单价";
        public const string ViewOrdXiaoji = "查看订单小计";
        public const string ViewOrdHeji = "查看订单合计";
        public const string ViewOrdZongji = "查看订单总计";
        public const string ViewOrdSettlement = "查看订单结算单信息";
        public const string ViewOrdReceipt = "查看订单收款管理信息";
        public const string ViewProductSupplier = "查看材料供应商";
        public const string ViewSampleProductSupplier = "查看样品供应商";
        public const string ViewEndProductSupplier = "查看成品供应商";
        public const string ViewProductCost = "查看材料成本";
        public const string ViewProductTotalAmount = "查看材料金额";
        public const string ViewSampleCost = "查看样品成本";
        public const string ViewSampleTotalAmount = "查看样品金额";
        public const string ViewEndProductCost = "查看成品成本";
        public const string ViewEndProductTotalAmount = "查看成品金额";

        public const string EditAccessControlManagement = "编辑权限管理页面";
        public const string EditDeliveryForm = "编辑送货安装单";
        public const string EditEnquiryForm = "编辑咨询单";
        public const string EditMachiningForm = "编辑生产单";
        public const string EditOrderForm = "编辑订单";
        public const string EditProductForm = "编辑产品";
        public const string EditPurchaseForm = "编辑采购单";
        public const string EditQuotationForm = "编辑报价单";
        public const string EditRefineForm = "编辑细化单";
        public const string EditSettlementForm = "编辑送货安装单";
        public const string EditSurveyForm = "编辑测量单";
        public const string EditSystemConfiguration = "编辑系统配置";

    }

    public static class FirstStatusConsts
    {
        public static readonly string Refine = "待细化";
        public static readonly string Enquiry = "新咨询单A";
        public static readonly string Quotation = "编辑中";
        public static readonly string Order = "编辑中";
        public static readonly string Mach = "新生产单";
        public static readonly string Delivery = "待提货";
        public static readonly string Settlement = "编辑中";
        public static readonly string Survey = "待测量";
        public static readonly string Purchase = "待采购";
    }

    public sealed class SysConst
    {
        public static readonly string SourceTypeEnquiry = "E";
        public static readonly string SourceTypeSalesOrder = "O";
        public static readonly string SourceTypeQuote = "Q";
        public static readonly string SourceTypeSurvey = "V";
        public static readonly string SourceTypeRefine = "R";
        public static readonly string SourceTypeOrder = "O";
        public static readonly string SourceTypeMaching = "M";
        public static readonly string SourceTypeDelivery = "D";
        public static readonly string SourceTypeSettlement = "T";
        public static readonly string SourceTypePurchase = "P";

        public static readonly string TableNameEnquiry = "Enquiry";
        public static readonly string SuffixEnquiry = "E";
        public static readonly string TableNameQuotation = "Quotation";
        public static readonly string SuffixQuotation = "Q";

        public static readonly string TableRefine = "Refine";
        public static readonly string SuffixRefine = "R";

        public static readonly string TableSurvey = "Survey";
        public static readonly string SuffixSuvey = "V";

        public static readonly string TableMachining = "Machining";
        public static readonly string SuffixMachining = "M";

        public static readonly string TableDelivery = "Delivery";
        public static readonly string SuffixDelivery = "D";

        public static readonly string TableSettlement = "Settlement";
        public static readonly string SuffixSettlement = "T";

        public static readonly string TablePurchaseOrder = "PurchaseOrder";
        public static readonly string SuffixPurchaseOrder = "P";

        public static readonly string TableOrder = "Order";
        public static readonly string SuffixOrder = "O";

        public static readonly string SampleDirectionTo = "To";
        public static readonly string SampleDirectionFrom = "From";

        public static readonly string SuveryCatelog = "测量类型";
        public static readonly string DeliveryCatelog = "送货方式";
        public static readonly string InstallCatelog = "安装类型";

        public static readonly string KeySourceType = "sourcetype";
        public static readonly string KeySourceNo = "sourceno";
        public static readonly string KeySourceId = "sourceid";

    }

    public static class YesNoConsts
    {
        public const string Yes = "是";
        public const string No = "否";
    }
}
