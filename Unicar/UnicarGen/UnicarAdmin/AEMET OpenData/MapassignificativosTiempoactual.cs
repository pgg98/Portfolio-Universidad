﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace UnicarAdmin
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using DefaultConnection;

    /// <summary>
    /// MapassignificativosTiempoactual operations.
    /// </summary>
    public partial class MapassignificativosTiempoactual : IServiceOperations<AEMETOpenData>, IMapassignificativosTiempoactual
    {
        /// <summary>
        /// Initializes a new instance of the MapassignificativosTiempoactual class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        public MapassignificativosTiempoactual(AEMETOpenData client)
        {
            if (client == null) 
            {
                throw new ArgumentNullException("client");
            }
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the AEMETOpenData
        /// </summary>
        public AEMETOpenData Client { get; private set; }

        /// <summary>
        /// Mapas significativos. Tiempo actual.
        /// </summary>
        /// Mapas significativos de ámbito nacional o CCAA, para el día actual (D+0),
        /// al día siguiente (D+1) o a los dos días (D+2), en el periodo horario de
        /// (00_12) ó (12-24).
        /// <param name='ambito'>
        /// | Código | Ámbito |
        /// |----------|----------|
        /// | esp  | España|
        /// | and  | Andalucía   |
        /// | arn  | Aragón   |
        /// | ast  | Asturias  |
        /// | bal  | Ballears, Illes   |
        /// | coo  | Canarias   |
        /// | can  | Cantabria   |
        /// | cle  | Castilla y León   |
        /// | clm  | Castilla - La Mancha   |
        /// | cat  | Cataluña   |
        /// | val  | Comunitat Valenciana   |
        /// | ext  | Extremadura   |
        /// | gal  | Galicia   |
        /// | mad  | Madrid, Comunidad de    |
        /// | mur  | Murcia, Región de   |
        /// | nav  | Navarra, Comunidad Foral de   |
        /// | pva  | País Vasco |
        /// | rio  | Rioja, La
        /// </param>
        /// <param name='dia'>
        /// | Código de día | Día |
        /// |----------|----------|
        /// | a | D+0 (00-12)  |
        /// | b  | D+0 (00-12)   |
        /// |  c | D+1 (00-12)  |
        /// | d  | D+1 (12-24) |
        /// | e  | D+2 (00-12) |
        /// | f  | D+2 (12-24)
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<object>> OneWithHttpMessagesAsync(string ambito, string dia, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ambito == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ambito");
            }
            if (dia == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "dia");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("ambito", ambito);
                tracingParameters.Add("dia", dia);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "One", tracingParameters);
            }
            // Construct URL
            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "api/mapasygraficos/mapassignificativos/{ambito}/{dia}").ToString();
            _url = _url.Replace("{ambito}", Uri.EscapeDataString(ambito));
            _url = _url.Replace("{dia}", Uri.EscapeDataString(dia));
            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new Uri(_url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 401 && (int)_statusCode != 404 && (int)_statusCode != 429)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<object>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<TwoZeroZero>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            // Deserialize Response
            if ((int)_statusCode == 401)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<FourZeroOne>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            // Deserialize Response
            if ((int)_statusCode == 404)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<FourZeroFour>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            // Deserialize Response
            if ((int)_statusCode == 429)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<FourTwoNine>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}