PEW.Utilities = {
    loadTemplate: function (template, callback) {
        var onError = function() {
            alert("Template {0} could not be loaded.".format(template));
        };
        
        this._request("/scripts/app/templates/{0}.html".format(template), "GET", callback, onError, "text", null);
    },
    get: function (url, callback, template, resultContainer) {
        
        if (template && resultContainer) {

            var onTemplateFetched = function(t) {
                resultContainer.html(t);
                PEW.Utilities.get(url, callback, null, null);
            };

            this.loadTemplate(template, onTemplateFetched);
            return;
        }

        this._request(url, "GET", callback, null, "json", null);
    },
    put: function (url, data, callback) {
        this._request(url, "PUT", callback, null, "json", data);
    },
    post: function (url, data, callback) {
        this._request(url, "POST", callback, null, "json", data);
    },
    delete: function (url, callback) {
        this._request(url, "DELETE", callback, null, "json", null);
    },
    _request: function (url, method, successCallback, errorCallback, type, data) {
        $.ajax({
            url: url,
            dataType: !type ? "json" : type,
            type: method,
            data: data,
            cache: false,
            contentType: type == "json" ? "application/json; charset=utf-8" : "application/x-www-form-urlencoded; charset=utf-8",
            success: function (d) {
                if (successCallback) successCallback(d);
            },
            error: function () {
                if (errorCallback) errorCallback();
            }
        });
    }
};