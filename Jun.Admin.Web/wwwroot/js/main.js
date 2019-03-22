
var adminApp = {
    //存放dom 对象类
    domObj: {
        //左边菜单外部容器
        navMenu: $('.adminui-navMenu'),
        //选项卡 div 容器
        navTabcenter: $('.adminui-navTab-center'),
        //
        pageContent: $('#pageContent')     
    },
   
    //程序初始化
    init: function () {

     

        //路由事件
        adminRouter.settings.callback = function (t, h, p) {
            //t:标题 h:链接地址 p:参数
            var hash = top.window.location.hash;
            var arry = hash.split("#!");
            adminApp.tabs.add({
                text: t,
                href: arry[2]
            });
            adminApp.menu.active(arry[2]);
        }

        adminApp.menu.active();

        $(".adminui-Container").on("click", "[router-href]", function () {
            var href = $(this).attr("router-href");
            var text = $(this).attr("router-text");
            adminRouter.load(text, href);
        });     


    },
    isPc: function () {
        return window.innerWidth > 768;
    },
    //菜单 操作类
    menu: {
        active: function (href) {//菜单激活
            if (!href) {
                var hash = window.location.hash;
                if (!hash) return;
                href = adminRouter.analysisHash(hash).key;
            }
            $('.adminui-navMenu a').removeClass('active');
            var activeDom = $('.adminui-navMenu a[router-href="' + href + '"]');
            activeDom.addClass('active');
         
        }
    },
    //选项卡类
    tabs: {
        //添加标签 obj={href:,text:}
        add: function (obj) {
            //var _url = href.substr(2);
            var ul = adminApp.domObj.navTabcenter.find('ul');
            var lis = ul.find('li');
            lis.removeClass('active');
            var flag = 0;
            //var url = '#!' + obj.text + '#!' + obj.href;
            for (var i = 0; i < lis.length; i++) {
                var btn = $(lis[i]).find('a[router-href="' + obj.href + '"]');
                //检测是否存在 标签页中
                if (btn.length > 0) {
                    //console.log(btn);
                    //存在，执行选中 并定位
                    flag = $(lis[i]);
                    $(lis[i]).addClass("active");
                    break;
                }
            }

            if (flag == 0) {
                //加入标签 
                flag = '<li class="active" title="' + obj.text + '">\
                                <a href="javascript:void(0)" router-href="'+ obj.href + '"router-text="' + obj.text + '">\
                                    <span>' + obj.text + '</span>\
                                </a>\
                        <i class="fa fa-close" onclick="hzy.tabs.close(event,$(this).parent())"></i>\
                            </li>';
                ul.append(flag);
                //创建 iframe
                adminApp.tabs.createIframe(obj.href);
            }
            adminApp.tabs.location($(flag));
            adminApp.tabs.active($(flag));
        },
        //创建 iframe
        createIframe: function (href) {
            console.log("加载 " + href);
            var PageContent = adminApp.domObj.pageContent;
            PageContent.find("iframe").removeClass("adminui-iframe-active");
            href = href.indexOf('#!') >= 0 ? href.substr(2) : href;
            var name = 'adminIframe-' + href;
            var html = '<iframe class="adminui-iframe adminui-iframe-active" frameborder="0" name="' + name + '"></iframe>';
            PageContent.append(html);
            var iframe = PageContent.find('iframe:visible');

            adminApp.tabs.loadIframe(iframe, href);
        },
        //关闭选项卡标签
        close: function (event, $this) {
            //阻止事件冒泡
            event.stopPropagation();
            $this = $($this);
            adminApp.tabs.upOrNextLoad($this, function () {
                var href = $this.find('a').attr('router-href');
                var PageContent = adminApp.domObj.pageContent;
                var name = 'adminIframe-' + (href.indexOf('#!') >= 0 ? href.substr(2) : href);
                PageContent.find("iframe[name='" + name + "']").remove();
                $this.remove();
            });
            return false;
        },
        //如果标签页面被关闭，调用该函数 来检查 加载上一个页面还是下一个页面
        upOrNextLoad: function (dom, callback) {
            //判断该关闭的选项卡是否是 选中状态  选中需要对 标签定位做调整
            dom = $(dom);
            var newDom = '';
            if (dom.hasClass("active")) {
                var up = dom.prev();//获取上一个元素
                var next = dom.next();//获取下一个元素
                if (up.length == 1) {
                    newDom = up;
                } if (next.length == 1) {
                    newDom = next;
                }
                var text = newDom.find("a").attr("router-text");
                var href = newDom.find("a").attr("router-href");
                adminRouter.load(text, href);
            }
            if (callback) callback();
        },
        //激活
        active: function (dom) {
            var dom = $(dom);

            //if (!dom.hasClass("active")) {
            //    dom.add("active");
            //}

            var href = dom.find('a').attr('router-href');
            var name = 'adminIframe-' + (href.indexOf('#!') >= 0 ? href.substr(2) : href);
            var PageContent = adminApp.domObj.pageContent;
            //请求页面并加载在页面中
            var iframe = PageContent.find("iframe[name='" + name + "']");
            if (!iframe.hasClass('adminui-iframe-active')) {
                PageContent.find("iframe").removeClass("adminui-iframe-active");
                iframe.addClass("adminui-iframe-active");
            }
        },
        //选项卡 选中后定位
        location: function (dom) {
            var dom = $(dom);
            var href = dom.find('a').attr('router-href');

            var lookDiv = adminApp.domObj.navTabcenter;//可见区域
            var ul = lookDiv.find("ul");
            var ulW = ul.find("li").length * 120;

            ul.css("width", ulW);
            var lookW = lookDiv.width();
            var lookLeft = lookDiv.offset().left;
            var ulleft = ul.offset().left;

            var thisDomInUlLeft = 0;//当前元素在 ul 中的 偏移量
            var lis = ul.find("li");
            for (var i = 0; i < lis.length; i++) {
                if ($(lis[i]).find('a').attr('router-href') == href) {
                    thisDomInUlLeft = (i + 1) * 120; break;
                }
            }

            var thisleft = parseInt((ulleft + thisDomInUlLeft));//当前选中的 li 偏移量
            //如果菜单藏入右边 那么向左移动
            if (thisleft >= parseInt(lookLeft + lookW)) {
                ul.animate({ "left": "-=" + parseInt(thisleft - parseInt(lookLeft + lookW)) + "px" }, 50);
            }
            //如果菜单藏入左边 那么向右移动
            if (parseInt(thisleft - 120) < lookLeft) {
                ul.animate({ "left": "+=" + parseInt(lookLeft - thisleft + 120) + "px" }, 50);
            }

        },
        // iframe 加载
        loadIframe: function (dom, src) {
            var _section = top.window.$("section.adminui-main");
            if (_section.find(".adminui-iframe-loader").length > 0) {
                _section.find(".adminui-iframe-loader").show();
            } else {
                _section.append("<div class='adminui-iframe-loader vertical-align text-center'><div class=\"loader-circle loader vertical-align-middle\" data-type=\"circle\"></div></div>");
            }

            dom.attr('src', src).on('load', function () {

                setTimeout(function () {
                    _section.find(".adminui-iframe-loader").hide();
                }, 100);

            });
        }


    },
    //全屏 类
    fullScreen: function () {
        var isFullScreen = false;
        var requestFullScreen = function () { //全屏
            var de = document.documentElement;
            if (de.requestFullscreen) {
                de.requestFullscreen();
            } else if (de.mozRequestFullScreen) {
                de.mozRequestFullScreen();
            } else if (de.webkitRequestFullScreen) {
                de.webkitRequestFullScreen();
            } else {
                alert("该浏览器不支持全屏");
            }
        };
        //退出全屏 判断浏览器种类
        var exitFull = function () {
            // 判断各种浏览器，找到正确的方法
            var exitMethod = document.exitFullscreen || //W3C
                document.mozCancelFullScreen || //Chrome等
                document.webkitExitFullscreen || //FireFox
                document.webkitExitFullscreen; //IE11
            if (exitMethod) {
                exitMethod.call(document);
            } else if (typeof window.ActiveXObject !== "undefined") { //for Internet Explorer
                var wscript = new ActiveXObject("WScript.Shell");
                if (wscript !== null) {
                    wscript.SendKeys("{F11}");
                }
            }
        };

        return {
            handleFullScreen: function ($this) {
                $this = $($this);
                if (isFullScreen) {
                    exitFull();
                    isFullScreen = false;
                    $this.find("i").removeClass("wb-contract");
                    $this.find("i").addClass("wb-expand");
                } else {
                    requestFullScreen();
                    isFullScreen = true;
                    $this.find("i").removeClass("wb-expand");
                    $this.find("i").addClass("wb-contract");
                }
            },
        };

    }()

}