$(function () {

    //#####################钻石参数相关###########################
    //----形状-----
    $(".shape>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".shape>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#shape").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#shape").val("");
        }
    });
    //-----颜色----
    $(".color>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".color>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#color").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#color").val("");
        }
    });
    //------净度-----
    $(".clarity>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".clarity>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#clarity").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#clarity").val("");
        }
    });
    //------切工-----
    $(".cut>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".cut>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#cut").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#cut").val("");
        }
    });
    //------抛光-----
    $(".polishing>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".polishing>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#polishing").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#polishing").val("");
        }
    });
    //------对称-----
    $(".symmetric>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".symmetric>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#symmetric").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#symmetric").val("");
        }
    });
    //------证书-----
    $(".certificate>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".certificate>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#certificate").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#certificate").val("");
        }
    });
    //------排序-----
    $(".sort>li").click(function () {
        $(this).toggleClass("hover");
        var str = "";
        $(".sort>li").each(function () {
            if ($(this).attr("class") == "hover") {
                str += $(this).attr("name") + "-";
            }
        });
        if (str.length > 0) {
            $("#sort").val(str.substring(0, str.lastIndexOf("-")));
        } else {
            $("#sort").val("");
        }
    });
    //################钻石列表查看#################################
    //查看功能
    $('.diam-login').click(function () {
        $('.diam-popover-mask').fadeIn(100);
        $(this).parents('.diam-buy').next('.diam-popover').slideDown(200);
    })
    //查看关闭
    $('.diam-poptit .close').click(function () {
        $('.diam-popover-mask').fadeOut(100);
        $(this).parents('.diam-poptit').parents('.diam-popover').slideUp(200);
    })
    //################钻石列表查询表单提交############################
    //表单提交
    function Filter(a, b) {
        var $ = function (e) { return document.getElementById(e); }
        var ipts = $('filterForm').getElementsByTagName('input'), result = [];
        for (var i = 0, l = ipts.length; i < l; i++) {
            if (ipts[i].getAttribute('to') == 'filter') {
                result.push(ipts[i]);
            }
        }
        if ($(a)) {
            $(a).value = b;
            for (var j = 0, len = result.length; j < len; j++) {

                if (result[j].value == '' || result[j].value == '0') {
                    result[j].parentNode.removeChild(result[j]);
                }
            }
            document.forms['filterForm'].submit();
        }
        return false;
    }
})