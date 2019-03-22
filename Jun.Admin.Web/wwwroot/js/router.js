/*----------------js路由-------------*/


//路由 对象
var adminRouter = {
    settings: {
        //路由触发 和加载 事件
        callback: null
    },
    //加载路由
    load: function (text, href) {
        if (href.slice(0, 2) != "#!") {
            href = "#!" + escape(text) + "#!" + href;
        }
        top.window.location.hash = href;
    },
    //初始化
    init: function () {
        window.addEventListener('load', function () {
            var hash = top.window.location.hash;
            if (hash.slice(0, 2) != "#!") return;
            var obj = adminRouter.analysisHash(hash);
            if (adminRouter.settings.callback) adminRouter.settings.callback(unescape(obj.text), obj.href, obj.parm);
        }, false);
        window.addEventListener('hashchange', function () {
            var hash = top.window.location.hash;
            if (hash.slice(0, 2) != "#!") return;
            var obj = adminRouter.analysisHash(hash);
            if (adminRouter.settings.callback) adminRouter.settings.callback(unescape(obj.text), obj.href, obj.parm);
        }, false);
    },
    //解析路由
    analysisHash: function (href) {
        //解析路由

        var site = href.split('#!');

        href = "#!" + site[2];

        var text = site[1];

        if (href.indexOf('#!') >= 0) {
            href = href.slice(2) || '/';
        } else {
            href = href || '/';
        }

        var parm = {};

        if (href.indexOf('/?') >= 0) {
            //检测是否有参数 /#!/User/Index/?id=1
            var _index = href.indexOf('/?');
            var _parm = href.substr(_index, href.length - _index).slice(2);

            if (_parm.indexOf('&') > 0) {
                var array = _parm.split('&');
                for (var i = 0; i < array.length; i++) {
                    var _arr = array[i].split('=');
                    parm[_arr[0]] = _arr[1];
                }
            } else {
                var _arr = _parm.split('=');
                parm[_arr[0]] = _arr[1];
            }

            href = href.substring(0, _index);
        }

        return {
            key: href,
            text: text,
            parm: parm
        };
    }
};