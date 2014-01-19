PEW.Models.SettingsModel = function (profile) {

    var self = this;
        this.isLoaded = profile != null;
    
    this.Id = profile ? profile.Id : "0";
    this.FirstName = ko.observable(profile ? profile.FirstName : "");
    this.LastName = ko.observable(profile ? profile.LastName : "");
    this.Email = ko.observable(profile ? profile.Email : "");
    this.GamerTag = ko.observable(profile ? profile.GamerTag : "");
    this.Game = ko.observable(profile ? profile.Game : "");
    this.HistoryCount = ko.observable(profile ? profile.HistoryCount : "");
    this.Theme = ko.observable(profile ? profile.Theme : "");
    this.Console = ko.observable(profile ? profile.Console : "");
    this.Friends = ko.observableArray(profile ? profile.Friends : []);

    this.addFriend = function () {
        var friend = $("#friend").val();
        if (friend) self.Friends.push(friend);
        this.save();
    };

    this.deleteFriend = function (friend) {
        var idx = self.Friends.indexOf(friend);
        if (idx >= 0) self.Friends.splice(idx, 1);
        this.save();
    };

    this.save = function () {
        if (!self.isLoaded) return;
        if (!self.Game && !self.GamerTag && !self.Console) return;

        var onSavedProfile = function () {
            App.session.update({ user: self.GamerTag });
        };

        var p = ko.toJSON(self);
        var url = "http://api.pew.nu/profile";

        if (self.Id == "0") PEW.Utilities.post(url, p, onSavedProfile);
        else PEW.Utilities.put(url, p, onSavedProfile);

    };
};