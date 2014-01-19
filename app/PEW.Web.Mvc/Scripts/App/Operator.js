PEW.Operator = function () {

    this.init = function() {

    };
    
    this.showMessage = function (data) {
        pubsubz.publish("send-message", data);
    };

    this.subscribeForMessages = function(callback) {
        pubsubz.subscribe("send-message", callback);
    };

    this.subscribe = function (type, callback) {
        pubsubz.subscribe(type, callback);
    };
};