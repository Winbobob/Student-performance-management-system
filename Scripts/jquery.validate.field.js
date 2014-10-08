﻿/*
 * Form Validate Function
 * Copyright (c) 2010 Arthur Zou
 */


$.ValidateField = {
    OK: "ok",
    chineseReg: /[^\x00-\xff]/g,
    emailReg: /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/i,
    telReg: /^[0-9]{3,}-[0-9]{6,8}$/,
    mobileReg: /^1[0-9]{10}$/,
    postcodeReg: /^\d{6}$/,
    cardIDReg: /^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/,
    numberReg: /^\d+$/,
    getStrLength: function (str) {
        return str.replace(this.chineseReg, "**").length;
    },
    ValidateUserName: function (userName) {
        var len = this.getStrLength(userName);
        if (len == 0) {
            return "用户名不能为空";
        }
        if (len < 3 || len > 20) {
            return "用户名长度不够或者超过范围";
        }
        if (userName.indexOf('\'') > -1) {
            return "用户名中含有的单引号为非法字符";
        }
        if (userName.indexOf('\"') > -1) {
            return "用户名中含有的双引号为非法字符";
        }
        return this.OK;
    },

    ValidatePassword: function (password) {
        var len = this.getStrLength(password);
        if (len == 0) {
            return "密码不能为空";
        }
        else if (len < 3 || len > 30) {
            return "密码长度不够或超出范围";
        }
        return this.OK;
    },
    ValidateConfirmPassword: function (password, confirmPassword) {
        var len = this.getStrLength(confirmPassword);
        if (len == 0) {
            return "请确认密码";
        }
        if (password != confirmPassword) {
            return "密码前后输入不一致";
        }
        return this.OK;
    },
    ValidateEmail: function (email) {
        var len = this.getStrLength(email);
        if (len == 0) {
            return "电子邮件不能为空";
        }
        if (!this.emailReg.test(email)) {
            return "电子邮件格式不正确";
        }
        return this.OK;
    },
    ValidateDate: function (date, flag) {
        var len = this.getStrLength(date);
        if (len > 0) {
            var ds = date.split('-');
            if (ds.length != 3) {
                return "日期格式不正确，无法转成正确的日期格式";
            } else {
                var d = new Date();
                d.setFullYear(ds[0], ds[1] - 1, ds[2]);
                var today = new Date();
                if (flag) {
                    if (d > today) {
                        return "所输入日期大于当前日期";
                    }
                } else {
                    if (d < today) {
                        return "所输入日期小于当前日期";
                    }
                }
            }
        }
        return this.OK;
    },
    ValidateCode: function (code) {
        var len = this.getStrLength(code);
        if (len == 0 || len>5) {
            return "验证码错误!";
        }
        return this.OK;
    },
    ValidateTel: function (tel) {
        var len = this.getStrLength(tel);
        if (len > 0) {
            if (!this.telReg.test(tel)) {
                return "电话号码格式不正确";
            }
        }
        return this.OK;
    },
    ValidateMobile: function (mobile, flag) {
        var len = this.getStrLength(mobile);
        if (flag && len == 0) {
            return "手机号码不能为空";
        }
        if (len > 0) {
            if (len != 11) {
                return "手机号码为11位的数字";
            }
            if (!this.mobileReg.test(mobile)) {
                return "手机号码格式不正确";
            }
        }
        return this.OK;
    },
    ValidateFax: function (fax) {
        var len = this.getStrLength(fax);
        if (len > 0) {
            if (!this.telReg.test(fax)) {
                return "传真号码格式不正确";
            }
        }
        return this.OK;
    },
    ValidatePostcode: function (postcode) {
        var len = this.getStrLength(postcode);
        if (len > 0) {
            if (!this.postcodeReg.test(postcode)) {
                return "邮政编码格式不正确";
            }
        }
        return this.OK;
    },
    ValidateCardID: function (cardID) {
        var len = this.getStrLength(cardID);
        if (len > 0) {
            if (!this.cardIDReg.test(cardID)) {
                return "身份证号码格式不正确";
            }
        }
        return this.OK;
    },
    ValidateNumber: function (number) {
        var len = this.getStrLength(number);
        if (len > 0) {
            if (!this.numberReg.test(number)) {
                return "请输入数字";
            }
        }
        return this.OK;
    },
    CommonValidata: function (fieldValue,fieldName,lengthMinRange) {
        var len = this.getStrLength(fieldValue);
        if (len < 1) {
            if (len < lengthMinRange || len > 50) {
                return fieldName + "长度不符合要求!";
            }
        }
        return this.OK;
    }
}  