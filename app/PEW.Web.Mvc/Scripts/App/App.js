/* Global variabel for application */
var App = App || {};
var Operator = Operator || {};

/* Run application */
$(function () {
    
    //handles events/messages
    Operator = new PEW.Operator();

    //starts the application
    App = new PEW.App();
    App.run();
});

/*
    Namespacing is good pratice! :-)
    http://elegantcode.com/2011/01/26/basic-javascript-part-8-namespaces/
    http://addyosmani.com/blog/essential-js-namespacing/
*/
var PEW = PEW || {
    Models: { }
};

PEW.Session = function () {
    var ctx = this;
    var _default = { user: "" };
    this._cookieName = "pew.stats.client.session";

    if ($.cookie(this._cookieName) == null) $.cookie(this._cookieName, JSON.stringify(_default), { expires: 365, path: '/' });

    this.update = function (data) {
        $.cookie(ctx._cookieName, JSON.stringify(data), { expires: 365, path: '/' });
    };

    this.destroy = function () {
        $.cookie(ctx._cookieName, null);
    };

    this.get = function () {
        var s = $.parseJSON($.cookie(ctx._cookieName));
        return s;
    };
    
};

PEW.App = function() {

    var self = this;

    //string format
    String.prototype.format = String.prototype.f = function () {
        var s = this, i = arguments.length;
        while (i--) { s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]); }
        return s;
    };

    //string format
    String.prototype.equals = String.prototype.eq = function (str) {
        return s === str;
    };

    //activate cors support
    $.support.cors = true;

    this.ui = new PEW.UI();
    this.session = new PEW.Session();
    this.router = new PEW.Router();

    return {
        session: this.session,
        ui: this.ui,
        operator: this.operator,
        run: function () {
            self.ui.init();
            self.router.init();
        }
    };
};













