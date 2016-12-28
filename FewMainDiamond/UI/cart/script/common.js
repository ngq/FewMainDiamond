/*
 * 共用JS入口模块（侧拉弹窗等）
 * */
window.toUrl = '';
define(function(require,exports,module){
/*通过 require 引入依赖*/
require('jquery');
// require('zepto');
// require('iscroll');
  
/*;(function($){

})(Zepto)*/

});

/**
 * 自动转跳
 */
function toRedirect(msg) {
	if(!msg){
        msg = '秒后';
	}
	window.toUrl = interval = setInterval(function(){
		var time = parseInt($('#countDown').attr('timeData'));
		var toUrl = $('#countDown').attr('toUrl');

		if(time==1){
		    window.location.href = toUrl;
		}else{
		    $('#countDown').html(msg.StringFormat((time - 1)));
		    $('#countDown').attr('timeData', time - 1);
		}
	},1000);
}

/* 
 用途：检查输入字符串是否为空或者全部都是空格 
 输入：str 
 返回： 
 如果全是空返回true,否则返回false 
 */
function isNull(str) {
    if (str == "")
        return true;
    var regu = "^[ ]+$";
    var re = new RegExp(regu);
    return re.test(str);
}

/* 
 用途：检查输入对象的值是否符合E-Mail格式 
 输入：str 输入的字符串 
 返回：如果通过验证返回true,否则返回false 
 
 */
function isEmail(str) {
    var myReg = /^[-_A-Za-z0-9\.]+@([-_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$/;
    if (myReg.test(str))
        return true;
    return false;
}


/* 
 用途：检查输入手机号码是否正确 
 输入： 
 s：字符串 
 返回： 
 如果通过验证返回true,否则返回false 
 
 */
function checkMobile(s) {
    var yidongreg = /^(134[012345678]\d{7}|1[34578][012356789]\d{8})$/;
	var dianxinreg = /^1[3578][01379]\d{8}$/;
	var liantongreg = /^1[34578][01256]\d{8}$/;
    var regu = /^((((0?)|((00)?))(((\s){0,2})|([-_－—\s]?)))|(([(]?)[+]?))(852)?([)]?)([-_－—\s]?)((2|3|5|6|9)?([-_－—\s]?)\d{3})(([-_－—\s]?)\d{4})$/;
    var re = new RegExp(regu);
	//var reg = /^1[3|4|5|7|8]\d{9}$/;//这一种也可以
	if (yidongreg.test(s) || dianxinreg.test(s) || liantongreg.test(s) || re.test(s)){
        return true;
    } else {
        return false;
    }
}

//String Format
//Usage ： var str = "{0}{1}".StringFormat("Eric", "Yu");
String.prototype.StringFormat = function() {
    if (arguments.length == 0) {
        return this;
    }

    for (var StringFormat_s = this, StringFormat_i = 0; StringFormat_i < arguments.length; StringFormat_i++) {
        StringFormat_s = StringFormat_s.replace(new RegExp("\\{" + StringFormat_i + "\\}", "g"), arguments[StringFormat_i]);
    }

    return StringFormat_s;
};

// 验证身份证
function IdentityValid(code) {
	var city={11:"北京",12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江 ",31:"上海",32:"江苏",33:"浙江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"河南",42:"湖北 ",43:"湖南",44:"广东",45:"广西",46:"海南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏 ",61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新疆",71:"台湾",81:"香港",82:"澳门",91:"国外 "};
    var tip = "";
    var pass= true;
    
    // if (!code || !/^\d{6}(18|19|20)?\d{2}(0[1-9]|1[12])(0[1-9]|[12]\d|3[01])\d{3}(\d|X)$/i.test(code)) {
    //     tip = "身份证号格式错误";
    //     pass = false;

    if (!code || !/^[1-9][0-9]{5}(19[0-9]{2}|200[0-9]|2010)(0[1-9]|1[0-2])(0[1-9]|[12][0-9]|3[01])[0-9]{3}[0-9xX]$/i.test(code)) {
        tip = "身份证号格式错误";
        pass = false;
                                                                   
    } else if (!city[code.substr(0,2)]) {
    	tip = "地址编码错误";
        pass = false;
    } else {
		//18位身份证需要验证最后一位校验位
		if (code.length == 18) {
			code = code.split('');
			//∑(ai×Wi)(mod 11)
			//加权因子
			var factor = [ 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 ];
			//校验位
			var parity = [ 1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2 ];
			var sum = 0;
			var ai = 0;
			var wi = 0;
			for (var i = 0; i < 17; i++) {
				ai = code[i];
				wi = factor[i];
				sum += ai * wi;
			}
			var last = parity[sum % 11];
			if (parity[sum % 11] != code[17]) {
				tip = "校验位错误";
				pass =false;
			}
		}
    }

    if (!pass) {
    	return tip;
    }

    return true;
}

// A923035(4)
/**
 * 验证香港居民证件
 */
function HKIdValid(code) {
	if (!code || !/^([a-zA-Z]{1})([\d]{7})$/i.test(code)) {
		return false;
	}

	var Symbof = {A: 1, B: 2, C: 3, D: 4, E: 5, F: 6, G: 7, H: 8, I: 9, J: 10, K: 11, L: 12, M: 13, N: 14, O: 15, P: 16, Q: 17, R: 18, S: 19, T: 20, U: 21, V: 22, W: 23, X: 24, Y: 25, Z: 26};
	var first = code.substr(0, 1).toUpperCase();

	var sum = parseInt(Symbof[first]) * 8;
	var middle = code.substr(0, code.length - 1);
	for (var i = 1; i < middle.length; i++) {
		sum += code[i] * (8 - i);
	}

	var parity = sum % 11;
	var ai = code.substr(code.length - 1, 1);

	var last = 0;
	if (parity == 1) {
		last = 'A';
	}

	if (parity > 1) {
		last = 11 - ai;
	}

	if (parity == last) {
		return true;
	}

	return false;
}

/**
 * 澳门正则验证:澳门：5215299（8）
 */
function MCIdValid(code) {
	if (!code || /^([157]{1})([/d]{7})([0-9A-Z])$/i.test(code)) {
		return false;
	}

	return true;
}

/**
 * 台湾证件验证
 * A 台北市 10; B 台中市 11; C 基隆市 12; D 台南市 13; E 高雄市 14; F 台北县 15; 
 * G 宜兰县 16; H 桃园县 17; I 嘉义市 34; J 新竹县 18; K 苗栗县 19; L 台中县 20; M 南投县 21; N 彰化县 22; 
 * O 新竹市 35; P 云林县 23; Q 嘉义县 24; R 台南县 25; S 高雄县 26; T 屏东县 27; 
 * U 花莲县 28; V 台东县 29; W 金门县 32; X 澎湖县 30; Y 阳明山管理局 31; Z 连江县 33; 
 * 台湾身份证：
 * 姓名	身份证号	性别	归属地
 * 曹虹亦	N286540421	女	彰化縣
 * 雷閱弟	E109676756	男	高雄市
 * 馬曉姣	O203882251	女	新竹市
 * 韋壇​​欄	A107142280	男	台北市
 */
function TWIdValid(code) {
	if (!code || !/^([a-zA-Z]{1})([12]{1})([\d]{8})$/i.test(code)) {
		return false;
	}

	var Symbof = {A: 10, B: 11, C: 12, D: 13, E: 14, F: 15, G: 16, H: 17, I: 34, J: 18, K: 19, L: 20, M: 21, N: 22, O: 35, P: 23, Q: 24, R: 25, S: 26, T: 27, U: 28, V: 29, W: 32, X: 30, Y: 31, Z: 33}
	var first = code.substr(0, 1).toUpperCase();

	var sum = parseInt(String(Symbof[first]).substr(0, 1)) + parseInt(String(Symbof[first]).substr(1, 1)) * 9;
	var middle = code.substr(1, code.length - 1);
	for (var i = 1; i < middle.length; i++) {
		sum += parseInt(code[i]) * (9 - i);
	}

	var parity = 10 - parseInt(String(sum).substr(String(sum).length - 1, 1));
	var last = code.substr(code.length - 1, 1);

	if (parity == last) {
		return true;
	}

	return false;
}

/**
 * 验证护照
 */
function PPIdValid(code) {
	if (!code || !/(^[A-Z]\d{7,8}$)|(^1[4,5]\d{7}$)|^(\d{9}$)|(^[A,Z]\d{7,8}$)/.test(code)) {
		return false;
	}

	return true;
}

/**
 * 弹窗口登录
 */
var loginDialog = function() {
	window.loginInterval = setInterval(function() {
		$.get('/ajax/login', function(res) {
			 //  console.log(res);
			if (res.result >= 0) {
				/*$('.phoNoLogin').hide();
				$('.phoLogin').show();
				$('.phoLogin span').html(res.nickname);
				$('.paPopupBg,.paPopup').fadeOut();*/
				location.reload();
				clearInterval(window.loginInterval);
			}
		});
	},1000);
};


/**
 * 自动关闭弹窗
 */
function toDjsHide(){
	var countDown = $('#countDown');
	var ctTimeNum,ctTimer;
	if(countDown){
		ctTimeNum = parseInt(countDown.attr('timeData'));
		ctTimer = setInterval(function(){
			ctTimeNum--;
			countDown.find('i').html(ctTimeNum+'秒后');
			if(ctTimeNum <= 0){
				clearInterval(ctTimer);
				window.location.href = countDown.attr('toUrl');
				$('.shopTips').hide();
				$('#countDown').find('i').html(ctTimeNum+'秒后');
			}
		},1000);
	}
}

/**
 *倒计时计算
 *  调用倒计时函数参考：
 	member.js：
	$('.time').each(function(){
		var _this = $(this);
		countDownMain(new Date(_this.text()),function(timeDate){
			_this.next('i').text((timeDate[0] == 0 ? 0 : timeDate[0])+'天'+(timeDate[1] == 0 ? 0 : timeDate[1])+'时'+(timeDate[2] == 0 ? 0 : timeDate[2])+'分'+(timeDate[3] == 0 ? 0 : timeDate[3])+'秒');
		});
	});
	//粉钻预约订单倒计时
	$('.haveDjs').each(function(){
		var _this = $(this);
		console.log(_this.attr('data-time'));
		countDownMain(new Date(_this.attr('data-time')),function(timeDate){
			_this.html('还有<i>' + (timeDate[0] == 0 ? 0 : timeDate[0]) +'</i>天<i>' + (timeDate[1] == 0 ? 0 : timeDate[1]) +'</i>时<i>' + (timeDate[2] == 0 ? 0 : timeDate[2]) +'</i>分<i>' + (timeDate[3] == 0 ? 0 : timeDate[3]) +'</i>秒发售</p>');
		});
	});
	pink.js：
	countDownMain(endTime,function(timeDate){
		var ids = ['#pink_day1','#pink_day2','#pink_time1','#pink_time2','#pink_minute1','#pink_minute2','#pink_second1','#pink_second2'];
    	for (var i = 0; i < timeDate.length; i++) {
    		$(ids[i == 0 ? 0 : i*2]).html(getOne(timeDate[i]));
    		$(ids[i == 0 ? 1 : i*2+1]).html(getTwo(timeDate[i]));
    	}
	});
 */
 function countDownMain(endTime,callBack){
 	//倒数计时
	var currentTime = Date.parse(new Date());
	currentTime = currentTime / 1000;

	var startTime = Date.parse(new Date(endTime));
	startTime = startTime / 1000;
	var times;
	//2014-07-10 10:21:12的时间戳为：1404958872 
	if(startTime > currentTime){
		//设置启动倒计时
		var recordTime=0;
	    var recordInterval=setInterval(function(){
	        recordTime++;
	        var currentDate = new Date();
	        var strEndTime = endTime;  //结束时间
	        var EndTime=new Date(strEndTime);
	        var days= EndTime - currentDate; 
	        var recordTime = parseInt(days / 1000);//精确到秒  
	        //调用计算倒计时函数，返回剩余时间数组
	        times = dateFormat(recordTime);
	        if(callBack){ 
	        	callBack(times);//回调函数
	        }
	    },1000);
	}
 }

 /** 
 * @param {} second 
 * @return {} 
 * @desc 秒转化成dd hh:mm:ss 
*/
function dateFormat(second){  
	var dd,hh,mm,ss; 
	second = typeof second === 'string' ? parseInt(second) : second; 
	if(!second || second < 0){ 
		return; 
	} 
	//天 
	dd = second / (24 * 3600) | 0; 
	second = Math.round(second) - dd * 24 * 3600; 
	//小时 
	hh = second / 3600 | 0; 
	second = Math.round(second) - hh * 3600; 
	//分 
	mm = second / 60 | 0; 
	//秒 
	ss = Math.round(second) - mm * 60; 
	if(Math.round(dd) < 10){ 
		dd = dd > 0 ? '0' + dd : ''; 
	} 
	
	var numList = [dd,hh,mm,ss]
	return numList; 
}
//获取剩余时间十位显示数值
function getOne(n){
	if(n < 10){
		return 0;
	}else{
		return parseInt(n/10);
	}
}
//获取剩余时间个位显示数值
function getTwo(n){
	return n%10;
}