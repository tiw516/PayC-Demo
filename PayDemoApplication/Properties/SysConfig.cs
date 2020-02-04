using System;

namespace PayDemoApplication.Properties
{
    public static class SysConfig
    {
        // ** TEST MERCHANT CODE**
        //public const string TestMerchantCode = "PINE";
        public const string TestMerchantCode = "ZZZ6";

        // ** TEST MERCHANT GATEWAY CREDENTIAL**
        //public const string TestMerchantGatewayCredential = "5FpQY08vuaHesby5fLKuvenxUtnCwy7S";
        public const string TestMerchantGatewayCredential = "2c5NmzajTLeaz5xFzeKldQ3vWARqfGkU";

        // AlphaPay Payment Application Host
        private const string PayHost = "https://pay.alphapay.ca";



        // Exchange Rate API
        public static string ExchangeRateApi(string merchantCode)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/{merchantCode}/channel_exchange_rate";
        }

        // Retail MicroPay API
        public static string RetailMicroPayApo(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/micropay/partners/" + merchantCode + "/orders/" + orderId;
        }

        // Retail Active QrCode API
        public static string RetailQrCodeApi(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/retail_qrcode/partners/" + merchantCode + "/orders/" + orderId;
        }



        // PC QR Code API
        public static string PCQrCodeApi(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId;
        }



        // Alipay Online Payment API
        public static string AlipayOnlineAPI(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/alipay/partners/" + merchantCode + "/orders/" + orderId;
        }


        //Query Order Status
        public static string QueryOrderStatusAPI(string merchantCode, string orderId)
        {
            //string timeStr = SignUtil.GetTimeStamp();
            //long time = Convert.ToInt64(timeStr);
            //string nonce_str = SignUtil.GenerateRandomStr(10);
            //string sign = SignUtil.GetSign(timeStr, nonce_str);

            //return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId + "time=" + time + "&nonce_str=" + nonce_str  + "&sign=" + sign;
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId;
        }


        //Apply for Refund
        public static string ApplyForRefundAPI(string merchantCode, string orderId, string refundId)
        {
            //string timeStr = SignUtil.GetTimeStamp();
            //long time = Convert.ToInt64(timeStr);
            //string nonce_str = SignUtil.GenerateRandomStr(10);
            //string sign = SignUtil.GetSign(timeStr, nonce_str);
            //return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId + "/refunds/" + refundId + "time=" + time + "&nonce_str=" + nonce_str + "&sign=" + sign;
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId + "/refunds/" + refundId;
        }

        //Query Refund Order Status
        public static string QueryRefundOrderStatusAPI(string merchantCode, string orderId, string refundId)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders/" + orderId + "/refunds/" + refundId;
        }

        //Check Orders
        public static string CheckOrdersAPI(string merchantCode)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/orders";
        }

        //Query Daily Transactions
        public static string QueryDailyTransactionsAPI(string merchantCode)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/" +  merchantCode + "/transactions" ;
        }

        //Query Settlement Details
        public static string QuerySettlementDetailsAPI(string merchantCode)
        {
            return $"{PayHost}/api/v1.0/gateway/partners/" + merchantCode + "/settlements";
        }

        //Create JSAPI Payment Order
        public static string CreateJSAPIPaymentOrderAPI(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/jsapi_gateway/partners/" + merchantCode + "/orders/" + orderId;
        }

        //Create H5 Alipay Payment
        public static string H5AlipayPaymentAPI(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/h5_payment/partners/" + merchantCode + "/orders/" + orderId;
        }

        //H5 Payment Page
        public static string H5AlipayPaymentPageAPI(string merchantCode, string orderId)
        {
            return $"{PayHost}/api/v1.0/h5_payment/partners/" + merchantCode + "/orders/" + orderId + "/pay";
        }



    }
}