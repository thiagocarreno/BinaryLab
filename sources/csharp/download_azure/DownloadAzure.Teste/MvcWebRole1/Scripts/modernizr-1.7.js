<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Facebook</name>
    </assembly>
    <members>
        <member name="T:Facebook.DateTimeConvertor">
            <summary>
            Utilities to convert dates to and from unix time.
            </summary>
        </member>
        <member name="M:Facebook.DateTimeConvertor.FromUnixTime(System.Double)">
            <summary>
            Converts a unix time string to a DateTime object.
            </summary>
            <param name="unixTime">The unix time.</param>
            <returns>The DateTime object.</returns>
        </member>
        <member name="M:Facebook.DateTimeConvertor.FromUnixTime(System.String)">
            <summary>
            Converts a unix time string to a DateTime object.
            </summary>
            <param name="unixTime">The string representation of the unix time.</param>
            <returns>The DateTime object.</returns>
        </member>
        <member name="M:Facebook.DateTimeConvertor.ToUnixTime(System.DateTime)">
            <summary>
            Converts a DateTime object to unix time.
            </summary>
            <param name="dateTime">The date time.</param>
            <returns>The unix date time.</returns>
        </member>
        <member name="M:Facebook.DateTimeConvertor.ToUnixTime(System.DateTimeOffset)">
            <summary>
            Converts a DateTimeOffset object to unix time.
            </summary>
            <param name="dateTime">The date time.</param>
            <returns>The unix date time.</returns>
        </member>
        <member name="M:Facebook.DateTimeConvertor.ToIso8601FormattedDateTime(System.DateTime)">
            <summary>
            Converts to specified <see cref="T:System.DateTime"/> to ISO-8601 format (yyyy-MM-ddTHH:mm:ssZ).
            </summary>
            <param name="dateTime">
            The date time.
            </param>
            <returns>
            Returns the string representation of date time in ISO-8601 format (yyyy-MM-ddTHH:mm:ssZ).
            </returns>
        </member>
        <member name="M:Facebook.DateTimeConvertor.FromIso8601FormattedDateTime(System.String)">
            <summary>
            Converts ISO-8601 format (yyyy-MM-ddTHH:mm:ssZ) date time to <see cref="T:System.DateTime"/>.
            </summary>
            <param name="iso8601DateTime">
            The ISO-8601 formatted date time.
            </param>
            <returns>
            Returns the <see cref="T:System.DateTime"/> equivalent to the ISO-8601 formatted date time. 
            </returns>
        </member>
        <member name="P:Facebook.DateTimeConvertor.Epoch">
            <summary>
            Gets the epoch time.
            </summary>
            <value>The epoch time.</value>
        </member>
        <member name="T:Facebook.FacebookClient">
            <summary>
            Provides access to the Facbook Platform.
            </summary>
        </member>
        <member name="M:Facebook.FacebookClient.CancelAsync">
            <summary>
            Cancels asynchronous requests.
            </summary>
            <remarks>
            Does not cancel requests created using XTaskAsync methods.
            </remarks>
        </member>
        <member name="M:Facebook.FacebookClient.ApiAsync(Facebook.HttpMethod,System.String,System.Object,System.Type,System.Object)">
            <summary>
            Makes an asynchronous request to the Facebook server.
            </summary>
            <param name="httpMethod">Http method. (GET/POST/DELETE)</param>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <param name="resultType">The type of deserialize object into.</param>
            <param name="userState">The user state.</param>
        </member>
        <member name="M:Facebook.FacebookClient.OnGetCompleted(Facebook.FacebookApiEventArgs)">
            <summary>
            Raise OnGetCompleted event handler.
            </summary>
            <param name="args">The <see cref="T:Facebook.FacebookApiEventArgs"/>.</param>
        </member>
        <member name="M:Facebook.FacebookClient.OnPostCompleted(Facebook.FacebookApiEventArgs)">
            <summary>
            Raise OnPostCompleted event handler.
            </summary>
            <param name="args">The <see cref="T:Facebook.FacebookApiEventArgs"/>.</param>
        </member>
        <member name="M:Facebook.FacebookClient.OnDeleteCompleted(Facebook.FacebookApiEventArgs)">
            <summary>
            Raise OnDeletedCompleted event handler.
            </summary>
            <param name="args">The <see cref="T:Facebook.FacebookApiEventArgs"/>.</param>
        </member>
        <member name="M:Facebook.FacebookClient.OnUploadProgressChanged(Facebook.FacebookUploadProgressChangedEventArgs)">
            <summary>
            Raise OnUploadProgressCompleted event handler.
            </summary>
            <param name="args">The <see cref="T:Facebook.FacebookApiEventArgs"/>.</param>
        </member>
        <member name="M:Facebook.FacebookClient.GetAsync(System.String)">
            <summary>
            Makes an asynchronous GET request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.GetAsync(System.Object)">
            <summary>
            Makes an asynchronous GET request to the Facebook server.
            </summary>
            <param name="parameters">The parameters</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.GetAsync(System.String,System.Object)">
            <summary>
            Makes an asynchronous GET request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.GetAsync(System.String,System.Object,System.Object)">
            <summary>
            Makes an asynchronous GET request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <param name="userState">The user state.</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.PostAsync(System.Object)">
            <summary>
            Makes an asynchronous POST request to the Facebook server.
            </summary>
            <param name="parameters">The parameters</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.PostAsync(System.String,System.Object)">
            <summary>
            Makes an asynchronous POST request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.PostAsync(System.String,System.Object,System.Object)">
            <summary>
            Makes an asynchronous POST request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <param name="userState">The user state.</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.DeleteAsync(System.String)">
            <summary>
            Makes an asynchronous DELETE request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.DeleteAsync(System.String,System.Object,System.Object)">
            <summary>
            Makes an asynchronous DELETE request to the Facebook server.
            </summary>
            <param name="path">The resource path or the resource url.</param>
            <param name="parameters">The parameters</param>
            <param name="userState">The user state.</param>
            <returns>The json result.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.BatchAsync(Facebook.FacebookBatchParameter[],System.Object,System.Object)">
            <summary>
            Makes an asynchronous request to the Facebook server.
            </summary>
            <param name="batchParameters">The list of batch parameters.</param>
            <param name="userState">The user state.</param>
            <param name="parameters">The parameters.</param>
        </member>
        <member name="M:Facebook.FacebookClient.BatchAsync(Facebook.FacebookBatchParameter[],System.Object)">
            <summary>
            Makes an asynchronous request to the Facebook server.
            </summary>
            <param name="batchParameters">The list of batch parameters.</param>
            <param name="userState">The user state.</param>
        </member>
        <member name="M:Facebook.FacebookClient.BatchAsync(Facebook.FacebookBatchParameter[])">
            <summary>
            Makes an asynchronous request to the Facebook server.
            </summary>
            <param name="batchParameters">The list of batch parameters.</param>
        </member>
        <member name="M:Facebook.FacebookClient.#cctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookClient"/> class.
            </summary>
        </member>
        <member name="M:Facebook.FacebookClient.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookClient"/> class.
            </summary>
        </member>
        <member name="M:Facebook.FacebookClient.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookClient"/> class.
            </summary>
            <param name="accessToken">The facebook access_token.</param>
            <exception cref="T:System.ArgumentNullException">Access token in null or empty.</exception>
        </member>
        <member name="M:Facebook.FacebookClient.SetDefaultJsonSerializers(System.Func{System.Object,System.String},System.Func{System.String,System.Type,System.Object})">
            <summary>
            Sets the default json seriazliers and deserializers.
            </summary>
            <param name="jsonSerializer">Json serializer</param>
            <param name="jsonDeserializer">Jsonn deserializer</param>
        </member>
        <member name="M:Facebook.FacebookClient.SetDefaultHttpWebRequestFactory(System.Func{System.Uri,Facebook.HttpWebRequestWrapper})">
            <summary>
            Sets the default http web request factory.
            </summary>
            <param name="httpWebRequestFactory"></param>
        </member>
        <member name="M:Facebook.FacebookClient.ToDictionary(System.Object,System.Collections.Generic.IDictionary{System.String,Facebook.FacebookMediaObject}@,System.Collections.Generic.IDictionary{System.String,Facebook.FacebookMediaStream}@)">
            <summary>
            Converts the parameters to IDictionary&lt;string,object&gt;
            </summary>
            <param name="parameters">The parameter to convert.</param>
            <param name="mediaObjects">The extracted Facebook media objects.</param>
            <param name="mediaStreams">The extracted Facebook media streams.</param>
            <returns>The converted dictionary.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.BuildHttpQuery(System.Object,System.Func{System.String,System.String})">
            <summary>
            Converts the parameters to http query.
            </summary>
            <param name="parameter">The parameter to convert.</param>
            <param name="encode">Url encoder function.</param>
            <returns>The http query.</returns>
            <remarks>
            The result is not url encoded. The caller needs to take care of url encoding the result.
            </remarks>
        </member>
        <member name="M:Facebook.FacebookClient.TryParseSignedRequest(System.String,System.String,System.Object@)">
            <summary>
            Tries parsing the facebook signed_request.
            </summary>
            <param name="appSecret">The app secret.</param>
            <param name="signedRequestValue">The signed_request value.</param>
            <param name="signedRequest">The parsed signed request.</param>
            <returns>True if signed request parsed successfully otherwise false.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.TryParseSignedRequest(System.String,System.Object@)">
            <summary>
            Tries parsing the facebook signed_request.
            </summary>
            <param name="signedRequestValue">The signed_request value.</param>
            <param name="signedRequest">The parsed signed request.</param>
            <returns>True if signed request parsed successfully otherwise false.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.ParseSignedRequest(System.String,System.String)">
            <summary>
            Parse the facebook signed_request.
            </summary>
            <param name="appSecret">The appsecret.</param>
            <param name="signedRequestValue">The signed_request value.</param>
            <returns>The parse signed_request value.</returns>
            <exception cref="T:System.ArgumentNullException">Throws if appSecret or signedRequestValue is null or empty.</exception>
            <exception cref="T:System.InvalidOperationException">If the signedRequestValue is an invalid signed_request.</exception>
        </member>
        <member name="M:Facebook.FacebookClient.ParseSignedRequest(System.String)">
            <summary>
            Parse the facebook signed_request.
            </summary>
            <param name="signedRequestValue">The signed_request value.</param>
            <returns>The parse signed_request value.</returns>
            <exception cref="T:System.ArgumentNullException">Throws if appSecret or signedRequestValue is null or empty.</exception>
            <exception cref="T:System.InvalidOperationException">If the signedRequestValue is an invalid signed_request.</exception>
        </member>
        <member name="M:Facebook.FacebookClient.Base64UrlDecode(System.String)">
            <summary>
            Base64 Url decode.
            </summary>
            <param name="base64UrlSafeString">
            The base 64 url safe string.
            </param>
            <returns>
            The base 64 url decoded string.
            </returns>c
        </member>
        <member name="M:Facebook.FacebookClient.ComputeHmacSha256Hash(System.Byte[],System.Byte[])">
            <summary>
            Computes the Hmac Sha 256 Hash.
            </summary>
            <param name="data">
            The data to hash.
            </param>
            <param name="key">
            The hash key.
            </param>
            <returns>
            The Hmac Sha 256 hash.
            </returns>
        </member>
        <member name="M:Facebook.FacebookClient.TryParseOAuthCallbackUrl(System.Uri,Facebook.FacebookOAuthResult@)">
            <summary>
            Try parsing the url to <see cref="T:Facebook.FacebookOAuthResult"/>.
            </summary>
            <param name="url">The url to parse</param>
            <param name="facebookOAuthResult">The facebook oauth result.</param>
            <returns>True if parse successful, otherwise false.</returns>
        </member>
        <member name="M:Facebook.FacebookClient.ParseOAuthCallbackUrl(System.Uri)">
            <summary>
            Parse the url to <see cref="T:Facebook.FacebookOAuthResult"/>.
            </summary>
            <param name="uri"></param>
            <returns></returns>
            <exception cref="T:System.NotImplementedException"></exception>
        </member>
        <member name="M:Facebook.FacebookClient.GetLoginUrl(System.Object)">
            <summary>
            Gets the Facebook OAuth login url.
            </summary>
            <param name="parameters">
            The parameters.
            </param>
            <returns>
            The login url.
            </returns>
            <exception cref="T:System.ArgumentNullException">
            If parameters is null.
            </exception>
        </member>
        <member name="M:Facebook.FacebookClient.GetLogoutUrl(System.Object)">
            <summary>
            Gets the Facebook OAuth logout url.
            </summary>
            <param name="parameters">
            The parameters.
            </param>
            <returns>
            The logout url.
            </returns>
        </member>
        <member name="E:Facebook.FacebookClient.GetCompleted">
            <summary>
            Event handler for get completion.
            </summary>
        </member>
        <member name="E:Facebook.FacebookClient.PostCompleted">
            <summary>
            Event handler for post completion.
            </summary>
        </member>
        <member name="E:Facebook.FacebookClient.DeleteCompleted">
            <summary>
            Event handler for delete completion.
            </summary>
        </member>
        <member name="E:Facebook.FacebookClient.UploadProgressChanged">
            <summary>
            Event handler for upload progress changed.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.Boundary">
            <remarks>For unit testing</remarks>
        </member>
        <member name="P:Facebook.FacebookClient.AccessToken">
            <summary>
            Gets or sets the access token.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.AppId">
            <summary>
            Gets or sets the app id.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.AppSecret">
            <summary>
            Gets or sets the app secret.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.IsSecureConnection">
            <summary>
            Gets or sets the value indicating whether to add return_ssl_resource as default parameter in every request.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.UseFacebookBeta">
            <summary>
            Gets or sets the value indicating whether to use Facebook beta.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.SerializeJson">
            <summary>
            Serialize object to json.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.DeserializeJson">
            <summary>
            Deserialize json to object.
            </summary>
        </member>
        <member name="P:Facebook.FacebookClient.HttpWebRequestFactory">
            <summary>
            Http web request factory.
            </summary>
        </member>
        <member name="T:Facebook.FacebookApiEventArgs">
            <summary>
            Represents the Facebook api event args.
            </summary>
        </member>
        <member name="F:Facebook.FacebookApiEventArgs._result">
            <summary>
            The result.
            </summary>
        </member>
        <member name="M:Facebook.FacebookApiEventArgs.#ctor(System.Exception,System.Boolean,System.Object,System.Object)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiEventArgs"/> class.
            </summary>
            <param name="error">
            The error.
            </param>
            <param name="cancelled">
            The cancelled.
            </param>
            <param name="userState">
            The user state.
            </param>
            <param name="result">
            The result.
            </param>
        </member>
        <member name="M:Facebook.FacebookApiEventArgs.GetResultData">
            <summary>
            Get the json result.
            </summary>
            <returns>
            The json result.
            </returns>
        </member>
        <member name="T:Facebook.FacebookApiLimitException">
            <summary>
            Represents errors that occur as a result of problems with the OAuth access token.
            </summary>
        </member>
        <member name="T:Facebook.FacebookApiException">
            <summary>
            Represent errors that occur while calling a Facebook API.
            </summary>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
            <param name="message">The message.</param>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor(System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">Type of the error.</param>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor(System.String,System.String,System.Int32)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">Type of the error.</param>
            <param name="errorCode">Code of the error.</param>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor(System.String,System.String,System.Int32,System.Int32)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">Type of the error.</param>
            <param name="errorCode">Code of the error.</param>
            <param name="errorSubcode">Subcode of the error.</param>
        </member>
        <member name="M:Facebook.FacebookApiException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="innerException">The inner exception.</param>
        </member>
        <member name="P:Facebook.FacebookApiException.ErrorType">
            <summary>
            Gets or sets the type of the error.
            </summary>
            <value>The type of the error.</value>
        </member>
        <member name="P:Facebook.FacebookApiException.ErrorCode">
            <summary>
            Gets or sets the code of the error.
            </summary>
            <value>The code of the error.</value>
        </member>
        <member name="P:Facebook.FacebookApiException.ErrorSubcode">
            <summary>
            Gets or sets the error subcode.
            </summary>
            <value>The code of the error subcode.</value>
        </member>
        <member name="M:Facebook.FacebookApiLimitException.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiLimitException"/> class. 
            </summary>
        </member>
        <member name="M:Facebook.FacebookApiLimitException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiLimitException"/> class. 
            </summary>
            <param name="message">
            The message.
            </param>
        </member>
        <member name="M:Facebook.FacebookApiLimitException.#ctor(System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiLimitException"/> class. 
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">The error type.</param>
        </member>
        <member name="M:Facebook.FacebookApiLimitException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookApiLimitException"/> class. 
            </summary>
            <param name="message">
            The message.
            </param>
            <param name="innerException">
            The inner exception.
            </param>
        </member>
        <member name="T:Facebook.FacebookMediaStream">
            <summary>
            Represents a media stream such as a photo or a video.
            </summary>
        </member>
        <member name="F:Facebook.FacebookMediaStream._value">
            <summary>
            The value of the media stream.
            </summary>
        </member>
        <member name="M:Facebook.FacebookMediaStream.SetValue(System.IO.Stream)">
            <summary>
            Sets the value of the media stream.
            </summary>
            <param name="value">The media stream value.</param>
            <returns>Facebook Media Stream</returns>
        </member>
        <member name="M:Facebook.FacebookMediaStream.GetValue">
            <summary>
            Gets the value of the media stream.
            </summary>
            <returns>The value of the media stream.</returns>
        </member>
        <member name="M:Facebook.FacebookMediaStream.Dispose">
            <summary>
            Releases all resources used by the <see cref="T:System.IO.Stream"/>.
            </summary>
        </member>
        <member name="P:Facebook.FacebookMediaStream.ContentType">
            <summary>
            Gets or sets the type of the content.
            </summary>
            <value>The type of the content.</value>
        </member>
        <member name="P:Facebook.FacebookMediaStream.FileName">
            <summary>
            Gets or sets the name of the file.
            </summary>
            <value>The name of the file.</value>
        </member>
        <member name="T:Facebook.FacebookUploadProgressChangedEventArgs">
            <summary>
            Represents Facebook api upload progress changed event args.
            </summary>
        </member>
        <member name="M:Facebook.FacebookUploadProgressChangedEventArgs.#ctor(System.Int64,System.Int64,System.Int64,System.Int64,System.Int32,System.Object)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookUploadProgressChangedEventArgs"/> class.
            </summary>
            <param name="bytesReceived">Bytes received.</param>
            <param name="totalBytesToReceive">Total bytes to receive.</param>
            <param name="bytesSent">Bytes sent.</param>
            <param name="totalBytesToSend">Total bytes to send.</param>
            <param name="progressPercentage">Progress percentage.</param>
            <param name="userToken">User token.</param>
        </member>
        <member name="P:Facebook.FacebookUploadProgressChangedEventArgs.BytesReceived">
            <summary>
            Bytes received.
            </summary>
        </member>
        <member name="P:Facebook.FacebookUploadProgressChangedEventArgs.TotalBytesToReceive">
            <summary>
            Total bytes to receive.
            </summary>
        </member>
        <member name="P:Facebook.FacebookUploadProgressChangedEventArgs.BytesSent">
            <summary>
            Bytes sent.
            </summary>
        </member>
        <member name="P:Facebook.FacebookUploadProgressChangedEventArgs.TotalBytesToSend">
            <summary>
            Total bytes to send.
            </summary>
        </member>
        <member name="T:Facebook.FacebookBatchParameter">
            <summary>
            Represents a batch parameter for the creating batch requests.
            </summary>
            <remarks>
            http://developers.facebook.com/docs/api/batch/
            </remarks>
        </member>
        <member name="M:Facebook.FacebookBatchParameter.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookBatchParameter"/> class.
            </summary>
        </member>
        <member name="M:Facebook.FacebookBatchParameter.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookBatchParameter"/> class.
            </summary>
            <param name="path">
            The resource path.
            </param>
        </member>
        <member name="M:Facebook.FacebookBatchParameter.#ctor(Facebook.HttpMethod,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookBatchParameter"/> class.
            </summary>
            <param name="httpMethod">
            The http method.
            </param>
            <param name="path">
            The resource path.
            </param>
        </member>
        <member name="M:Facebook.FacebookBatchParameter.#ctor(System.String,System.Object)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookBatchParameter"/> class.
            </summary>
            <param name="path">
            The resource path.
            </param>
            <param name="parameters">
            The parameters.
            </param>
        </member>
        <member name="M:Facebook.FacebookBatchParameter.#ctor(Facebook.HttpMethod,System.String,System.Object)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookBatchParameter"/> class.
            </summary>
            <param name="httpMethod">
            The http method.
            </param>
            <param name="path">
            The resource path.
            </param>
            <param name="parameters">
            The parameters.
            </param>
        </member>
        <member name="P:Facebook.FacebookBatchParameter.HttpMethod">
            <summary>
            Gets or sets the http method.
            </summary>
        </member>
        <member name="P:Facebook.FacebookBatchParameter.Path">
            <summary>
            Gets or sets the resource path.
            </summary>
        </member>
        <member name="P:Facebook.FacebookBatchParameter.Parameters">
            <summary>
            Gets or sets the parameters.
            </summary>
        </member>
        <member name="P:Facebook.FacebookBatchParameter.Data">
            <summary>
            Gets or sets the raw data parameter.
            </summary>
        </member>
        <member name="T:Facebook.FacebookMediaObject">
            <summary>
            Represents a media object such as a photo or video.
            </summary>
        </member>
        <member name="F:Facebook.FacebookMediaObject._value">
            <summary>
            The value of the media object.
            </summary>
        </member>
        <member name="M:Facebook.FacebookMediaObject.SetValue(System.Byte[])">
            <summary>
            Sets the value of the media object.
            </summary>
            <param name="value">The media object value.</param>
            <returns>Facebook Media Object</returns>
        </member>
        <member name="M:Facebook.FacebookMediaObject.GetValue">
            <summary>
            Gets the value of the media object.
            </summary>
            <returns>The value of the media object.</returns>
        </member>
        <member name="P:Facebook.FacebookMediaObject.ContentType">
            <summary>
            Gets or sets the type of the content.
            </summary>
            <value>The type of the content.</value>
        </member>
        <member name="P:Facebook.FacebookMediaObject.FileName">
            <summary>
            Gets or sets the name of the file.
            </summary>
            <value>The name of the file.</value>
        </member>
        <member name="T:Facebook.FacebookOAuthException">
            <summary>
            Represents errors that occur as a result of problems with the OAuth access token.
            </summary>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
            <param name="message">The message.</param>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor(System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">The error type.</param>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor(System.String,System.String,System.Int32)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">Type of the error.</param>
            <param name="errorCode">Code of the error.</param>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor(System.String,System.String,System.Int32,System.Int32)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="errorType">Type of the error.</param>
            <param name="errorCode">Code of the error.</param>
            <param name="errorSubcode">Subcode of the error.</param>
        </member>
        <member name="M:Facebook.FacebookOAuthException.#ctor(System.String,System.Exception)">
            <summary>
            Initializes a new instance of the <see cref="T:Facebook.FacebookOAuthException"/> class.
            </summary>
            <param name="message">The message.</param>
            <param name="innerException">The inner exception.</param>
        </member>
        <member name="T:Facebook.FacebookOAuthResult">
            <summary>
            Represents the authentication result of Facebook.
            </summary>
        </member>
        <member name="F:Facebook.FacebookOAuthResult._accessToken">
            <summary>
            The access token.
            </summary>
        </member>
        <member name="F:Facebook.FacebookOAuthResult._expires">
            <summary>
            Date and Time when the access token expires.
            </summary>
        </member>
        <member name="F:Facebook.FacebookOAuthResult._error">
            <summary>
            Error that happens when using OAuth2 protocol.
            </summary>
        </member>
        <member name="F:Facebook.FacebookOAuthResult._error