﻿"use strict";
var App = /** @class */ (function () {
    function App() {
    }
    App.setCookie = function (name, value, seconds) {
        var date = new Date();
        date.setSeconds(date.getSeconds() + seconds);
        document.cookie = "".concat(name, "=").concat(value, ";expires=").concat(date.toUTCString(), ";path=/");
    };
    App.getCookie = function (name) {
        var _a;
        // https://stackoverflow.com/a/25490531/2720104
        return ((_a = document.cookie.match('(^|;)\\s*' + name + '\\s*=\\s*([^;]+)')) === null || _a === void 0 ? void 0 : _a.pop()) || null;
    };
    App.removeCookie = function (name) {
        document.cookie = "".concat(name, "=; Max-Age=0");
    };
    App.goBack = function () {
        window.history.back();
    };
    App.setBodyOverflow = function (hidden) {
        document.body.style.overflow = hidden ? "hidden" : "auto";
    };
    App.applyBodyElementClasses = function (cssClasses, cssVariables) {
        cssClasses === null || cssClasses === void 0 ? void 0 : cssClasses.forEach(function (c) { return document.body.classList.add(c); });
        Object.keys(cssVariables).forEach(function (key) { return document.body.style.setProperty(key, cssVariables[key]); });
    };
    return App;
}());

function getBlazorCulture() {
    return localStorage['BlazorCulture'];
}
function setBlazorCulture(value) {
    let text;
    if (value == "fa-IR") {
        text = "rtl";
    }
    else if (value == "en-US") {
        text = "ltr";
    }
    var element = document.getElementsByTagName("html");
    //debugger;
    //element.attr("dir", text)
    localStorage['BlazorCulture'] = value;
}

function floatLabelClick(_label) {
    let _input = _label.nextElementSibling;
    _input.focus();
}
function floatInputFocus(_input) {
    let _label = _input.previousElementSibling;
    _label.classList.add("floated-label");
}
function floatInputFocusOut(_input) {
    if (_input && _input.value) {
        return;
    }
    let _label = _input.previousElementSibling;
    _label.classList.remove("floated-label");
}

function checkFloatInputOnload() {
    var inputs = document.getElementsByClassName("form-group-input");

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value) {
            floatInputFocus(inputs[i]);
            floatInputFocusOut(inputs[i]);
        }
    }
}