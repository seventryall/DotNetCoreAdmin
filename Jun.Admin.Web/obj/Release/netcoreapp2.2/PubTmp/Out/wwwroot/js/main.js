layui.use('element', function () {
    var $ = layui.jquery;
    var element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
    $(".layui-tab-title .layui-tab-close").hide();
    var layFilter = "layadmin-layout-tabs";
    var tabs = {
        add: function (id, name, url) {
            var $tabs = $(".layui-tab li[lay-id]");
            var tabExist = false;
            if ($tabs.length > 1) {
                $.each($tabs, function () {
                    if ($(this).attr("lay-id") == id) {
                        tabExist = true;
                    }
                });
            }
            if (!tabExist) {
                var iframeName = 'adminIframe-' + url;
                //url = "https://www.layui.com/admin/std/dist/views/app/forum/list.html";
                var iframeHtml = '<iframe class="layadmin-iframe" frameborder="0"   scrolling="no"' +
                    '  src="' + url + '" name="' + iframeName + '"></iframe>';

                element.tabAdd(layFilter, {
                    title: name,
                    content: iframeHtml,
                    id: id //规定好的id
                })
            }

            this.change(id);
            var iframe = $('iframe[name="' + iframeName + '"]')[0];
            if (!tabExist) {
                iframe.height = window.document.documentElement.clientHeight + "px";

            }
        },
        change: function (layid) {
            //切换到指定Tab项
            element.tabChange(layFilter, layid); //根据传入的id传入到指定的tab项
        },
        delete: function (layid) {
            element.tabDelete(layFilter, layid);//删除
        },
        deleteAll: function (layids) {//删除所有
            $.each(layids, function (i, layid) {
                element.tabDelete(layFilter, layid);
            })
        }

    };
    $(".app-container").on("click", "[lay-id]", function () {
        var item = $(this);
        tabs.add(item.attr("lay-id"), item.attr("tab-text"), item.attr("lay-id"));
    });
    function FrameWH($iframe) {
        var temph = $iframe[0].contentDocument.body.scrollHeight;
        var height = temph > 400 ? temph : height;//给与一个界限
        $iframe.css("height", height + "px");
    }

    function setIframeHeight($iframe) {
       // var iframe = $('iframe');
        var height = window.parent.document.documentElement.scrollHeight - 165;//获取父页面高度减去差值
        if (document.all) { //判读ie w3c
            $iframe.attachEvent("onload", function () { //ie 判断加载 
                var temph = iframe.contentWindow.document.documentElement.scrollHeight;
                $iframe.height = temph > 400 ? temph : height;//给与一个界限
            });
        } else {
            $iframe.on("load", function () {
                var temph = iframe.contentDocument.body.scrollHeight;
                var height = temph > 400 ? temph : height;//给与一个界限
                $iframe.css("height", height + "px");
                //$iframe.height = temph > 400 ? temph : height;//给与一个界限
            });
            //$iframe.onload = function () { //w3c判断加载
              
            //}
        }
    }

    //$(window).resize(function () {
    //    FrameWH();
    //});
    element.on('tab(layadmin-layout-tabs)', function (data) {
      //  console.log(this); //当前Tab标题所在的原始DOM元素
       // console.log(data.index); //得到当前Tab的所在下标
      //  console.log(data.elem); //得到当前的Tab大容器
        var layid = data.elem.find("li.layui-this").attr("lay-id");
        $(".layui-side-menu dd.layui-this").removeClass("layui-this");
        $(".layui-side-menu a[lay-id='" + layid + "']").parent().addClass("layui-this");
    });
});
