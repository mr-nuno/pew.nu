PEW.Message = function () {
    var self = this;

    this.init = function() {
        Operator.subscribeForMessages(function (event, data) {
            self.render(data.title, data.message);
        });
    };

    this.render = function(title, message) {

        var onTemplateFetched = function (t) {
            $("#messages").html(t);
            ko.applyBindings(new PEW.Models.MessageModel(title, message));
        };

        PEW.Utilities.loadTemplate("message", onTemplateFetched);

    };
};