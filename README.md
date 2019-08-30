# DotNetCoreAdmin
## 简介
基于后端dotnetcore+efcore，前端layui的后台管理系统。<br>
许多功能未完善，有一些bug,目前仅做页面展示，更多说明可点击演示地址进入主页查看。<br>
演示地址：http://149.129.97.47:5000
## linux下部署
*    .net core sdk安装<br>
参考：https://dotnet.microsoft.com/download/linux-package-manager/centos/sdk-current <br>
*    sql server 安装 <br>
本示例使用的是sql server数据库，若使用mysql，linux下通过docker安装较为简单，而linux下安装sql server，会出现2g内存的限制，wtf！如果服务器内存足够，请忽略这步。<br>
关于如何解决这个问题，网上关于通过python修改内存限制的，经过测试，行不通。不过可通过下面方案解决：<br>
>1. 安装docker <br>
>2. 运行：docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d justin2004/mssql_server_tiny,
   其中 “justin2004/mssql_server_tiny” 这个镜像是别人制作好的，可直接拉取下来使用，而且已经解决了内存的限制。  <br>
>3. 当然也可以制作自己的镜像，参考：https://github.com/justin2004/mssql_server_tiny  <br>
*    运行项目
      - 切换到项目目录，运行：dotnet Jun.Admin.Web.dll --urls http://*:5000
      - supervisor守护进程，如何配置参考网上教程



