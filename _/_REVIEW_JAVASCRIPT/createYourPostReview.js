/////////////////////////////SCRIPT//////////////////////////////
var CONTENT = ___CONTENT___;
var PHOTO_IDS = ___PHOTO_IDS___;
(function(xhr) {
    console.log('injeced file.');

    var XHR = XMLHttpRequest.prototype;

    var open = XHR.open;
    var send = XHR.send;
    var setRequestHeader = XHR.setRequestHeader;

    XHR.open = function(method, url) {
        this._method = method;
        this._url = url;
        this._requestHeaders = {};
        this._startTime = (new Date()).toISOString();
        return open.apply(this, arguments);
    };

    XHR.setRequestHeader = function(header, value) {
        this._requestHeaders[header] = value;
        return setRequestHeader.apply(this, arguments);
    };

    XHR.send = function(postData) {

        this.addEventListener('load', function() {
            var endTime = (new Date()).toISOString();

            var myUrl = this._url ? this._url.toLowerCase() : this._url;
            if (myUrl && this._url === '/api/graphql/') {

                if (postData) {
                    if (typeof postData === 'string') {
                        try {
                            // here you get the REQUEST HEADERS, in JSON format, so you can also use JSON.parse
                            this._requestHeaders = postData;
                        } catch (err) {
                            // console.log('Request Header JSON decode failed, transfer_encoding field could be base64');
                            // console.log(err);
                        }
                    } else if (typeof postData === 'object' || typeof postData === 'array' || typeof postData === 'number' || typeof postData === 'boolean') {
                        // do something if you need
                    }
                }

                // here you get the RESPONSE HEADERS
                var responseHeaders = this.getAllResponseHeaders();

                if (this.responseType != 'blob') {
                    // responseText is string or null
                    try {
                        if (this._requestHeaders.contains('fb_api_req_friendly_name=ComposerStoryCreateMutation')) {
                            // here you get RESPONSE TEXT (BODY), in JSON format, so you can use JSON.parse
                            var arr = this.responseText;

                            // printing url, request headers, response headers, response body, to console

                            console.log(this._url);
                            console.log(this._requestHeaders);
                            console.log(responseHeaders);
                            console.log(arr);
                        }
                    } catch (err) {
                        // console.log('Error in responseType try catch');
                        // console.log(err);
                    }
                }

            }
        });
        if (this._url === '/api/graphql/') {
            console.log(this._url);
            if (arguments[0] &&
                arguments[0].contains('fb_api_req_friendly_name=ComposerStoryCreateMutation')
            ) {
                console.log('___REVIEW_PAGE_API___')
                var payload = new URLSearchParams(arguments[0]);
                var variables = JSON.parse(payload.get('variables'));
                console.log(CONTENT);
                variables.input.message.text = CONTENT;
                if (PHOTO_IDS) {
                    console.log(PHOTO_IDS);
                    variables.input.attachments = PHOTO_IDS.map(photo_id => {
                        return {
                            photo: {
                                id: photo_id
                            }
                        }
                    });
                }
                payload.set('variables', JSON.stringify(variables));
                arguments[0] = payload.toString();
                console.log(arguments)
            }
        }
        return send.apply(this, arguments);
    };

})(XMLHttpRequest);
/////////////////////////////SCRIPT//////////////////////////////