PEW.UI = function () {
    var self = this;
    this.message = new PEW.Message();

    this.init = function() {
        self.message.init();
    };

    this.block = function () {
        $.blockUI({ 
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff'
            }
        });
    };

    this.unblock = function () {
        $.unblockUI();
    };

    this.container = function() {
        return $("#content");
    };

    this.showMessage = function(title, message) {
        Operator.showMessage({ title: title, message: message });
    };

    this.init();
};