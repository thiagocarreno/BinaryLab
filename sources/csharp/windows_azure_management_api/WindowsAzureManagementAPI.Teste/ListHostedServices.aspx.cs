#wpadminbar *{font-family:Tahoma,Arial,Helvetica,sans-serif}#wpadminbar{direction:rtl;font-family:Tahoma,Arial,Helvetica,sans-serif;left:auto;right:0}#wpadminbar .quicklinks{border-left:0;border-right:1px solid transparent}#wpadminbar .quicklinks ul{text-align:right}#wpadminbar li{float:right}#wpadminbar .quicklinks>ul>li{border-right:0;border-left:1px solid #555}#wpadminbar .quicklinks>ul>li>a,#wpadminbar .quicklinks>ul>li>.ab-empty-item{border-right:0;border-left:1px solid #333}#wpadminbar .quicklinks .ab-top-secondary>li{border-left:0;border-right:1px solid #333;float:left}#wpadminbar .quicklinks .ab-top-secondary>li>a,#wpadminbar .quicklinks .ab-top-secondary>li>.ab-empty-item{border-right:1px solid #555;border-left:0}#wpadminbar .menupop .ab-sub-wrapper,#wpadminbar .shortlink-input{margin:0 -1px 0 0}#wpadminbar.ie7 .menupop .ab-sub-wrapper,#wpadminbar.ie7 .shortlink-input{left:auto;right:0}#wpadminbar .ab-top-secondary .menupop .ab-sub-wrapper{right:auto;left:0;margin:0 0 0 -1px}#wpadminbar .menupop li:hover>.ab-sub-wrapper,#wpadminbar .menupop li.hover>.ab-sub-wrapper{margin-left:0;margin-right:100%}#wpadminbar .ab-top-secondary .menupop li:hover>.ab-sub-wrapper,#wpadminbar .ab-top-secondary .menupop li.hover>.ab-sub-wrapper{margin-left:inherit;margin-right:0;left:100%;right:inherit}#wpadminbar .menupop .menupop>.ab-item{background-position:5% -46px;padding-left:2em;padding-right:1em}#wpadminbar .ab-top-secondary .menupop .menupop>.ab-item{background-position:95% -20px;padding-left:1em;padding-right:2em}#wpadminbar .quicklinks .menupop ul.ab-sub-secondary{right:0;left:auto}#wpadminbar .ab-top-secondary{float:left;right:auto;left:0}#wpadminbar ul li:last-child,#wpadminbar ul li:last-child .ab-item{border-left:0}#wpadminbar #wp-admin-bar-my-account.with-avatar #wp-admin-bar-user-actions>li{margin-right:88px;margin-left:16px}#wp-admin-bar-user-actions>li>.ab-item{padding-left:0;padding-right:8px}#wp-admin-bar-user-info .avatar{left:auto;right:-72px}#wpadminbar .quicklinks li#wp-admin-bar-my-account.with-avatar>a img{margin-left:-1px;margin-right:4px}#wpadminbar .quicklinks li img.blavatar{margin-right:0;margin-left:4px}#wpadminbar #adminbarsearch .adminbar-input{font-family:Tahoma,Arial,Helvetica,sans-serif;padding:0 24px 0 3px;margin:0;background-position:50% 2px}#wpadminbar #adminbarsearch .adminbar-input:focus,#wpadminbar.ie7 #adminbarsearch .adminbar-input{background-position:99% 2px}#wpadminbar .ab-icon{float:right}.ie7 #wp-admin-bar-wp-logo>.ab-item .ab-icon{position:static}#wpadminbar.ie7 .ab-icon{float:left;left:12px}#wpadminbar .ab-label{margin-left:0;margin-right:4px;float:left}#wpadminbar.ie7 .ab-label{margin-right:0}#wpadminbar.ie7 #wp-admin-bar-comments>a{min-width:25px}#wpadminbar a:hover .ab-comments-icon-arrow{border-right-color:#bbb}#wpadminbar .menupop .ab-sub-wrapper,#wpadminbar .shortlink-input{right:0}#wpadminbar .quicklinks .menupop ul li a{position:relative}* html #wpadminbar .quicklinks ul li a{float:right}                                                                                     es";
            Uri uri = new Uri(String.Format(uriFormat, subscriptionId));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "GET";
            request.Headers.Add("x-ms-version", version);
            request.ClientCertificates.Add(certificate);
            request.ContentType = "application/xml";

            XDocument responseBody = null;
            HttpStatusCode statusCode;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                // GetResponse throws a WebException for 400 and 500 status codes
                response = (HttpWebResponse)ex.Response;
            }
            statusCode = response.StatusCode;
            if (response.ContentLength > 0)
            {
                using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
                {
                    responseBody = XDocument.Load(reader);
                }
            }
            response.Close();
            if (statusCode.Equals(HttpStatusCode.OK))
            {
                XNamespace wa = "http://schemas.microsoft.com/windowsazure";
                XElement hostedServices = responseBody.Element(wa + "HostedServices");
                Response.Write(String.Format(
                    "Hosted Services for Subscription ID {0}:{1}{2}<br />",
                    subscriptionId,
                    "<br />",
                    hostedServices.ToString(SaveOptions.OmitDuplicateNamespaces)));
            }
            else
            {
                Response.Write("Call to List Hosted Services returned an error:");
                Response.Write(String.Format("Status Code: {0} ({1}):{2}{3}<br />",
                    (int)statusCode, statusCode, "<br />",
                    responseBody.ToString(SaveOptions.OmitDuplicateNamespaces)));
            }
            return;
        }
    }
}