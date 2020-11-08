using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace cs
{
    public static class hwd
{
    //======================================================
    //函数名称：hwd_getStr
    //返回类型：String
    //函数说明：通过指针地址返回字符串.
    //参数<1>：int buffer，缓冲区地址
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    public static string hwd_getStr(int buffer, int bufferLen)
    {
        IntPtr bufferPtr = new IntPtr(buffer);
        return Marshal.PtrToStringAnsi(bufferPtr);
    }

    //======================================================
    //函数名称：hwd_fastCheck
    //返回类型：bool 
    //函数说明：快速验证,作者临时接单,一条命令快速接入验证,数据安全的前提下,防止被骗软件.此命令只需运行一次,程序结束前每隔几分钟自动校验一次.
    //参数<1>：string url，授权域名
    //参数<2>：string webkey，通用秘钥,购买时获得
    //参数<3>：string sid，软件ID,网页后台添加软件后获取
    //参数<4>：string key，通讯秘钥,网页后台添加软件后获取
    //参数<5>：string softPara，软件自定义常量,只要用户未付款,此处一定留空. 如果用户付款,请将此软件的自定义常量写到此处,将不再联网验证.也可在软件调试时使用.
    //参数<6>：int checkDebug，发现调试器后续,0=无操作,1=退出,2=蓝屏,注意,仅在开发模式请设置为0,正式发布一定非零.内核级防调试,近20种反调试手段,设置蓝屏后遇到调试器不一定马上蓝屏,看调试者技术.满足一定条件才会触发蓝屏.
    //参数<7>：int checkVirtualMachine，发现虚拟机运行后续,0=无操作,1=退出,2=蓝屏,一般软件禁止虚拟机运行,防止不法分子使用虚拟机调试.
    //参数<8>：string port，网站端口,可空,默认为80端口.仅支持3种端口号,80,443,999 端口解释:80为http协议,443为https协议,如网站启用https,请使用443端口.999为http指定端口,方便未备案域名使用大陆服务器.
    //参数<9>：bool ui，TRUE:启用界面库,FALSE:不启用界面库,如不启用,所有内置窗口资源均不可用,例如:loading窗口,hwd_loadLoginWindow(),hwd_msgBox(),hwd_msg(),断网重连窗口.等一切内置窗口资源及函数.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_fastCheck(string url, string webkey, string sid, string key, string softPara, int checkDebug, int checkVirtualMachine, string port, bool ui);

    //======================================================
    //函数名称：hwd_save
    //返回类型：bool 
    //函数说明：快速写配置,自动创建"程序目录\config.dat",保存程序所需配置,配合hwd_read(string name);读取.
    //参数<1>：string name，配置名称
    //参数<2>：string value，配置值
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_save(string name, string value);

    //======================================================
    //函数名称：hwd_read
    //返回类型：int 
    //函数说明：快速读配置,可读取hwd_save();函数写下的配置.
    //参数<1>：string name，配置名称
    //参数<2>：string defaultValue，默认返回值
    //参数<3>：int buffer，缓冲区
    //参数<4>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_read(string name, string defaultValue, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getMachineCode
    //返回类型：int 
    //函数说明：获取机器码.例:DE0F71AD-EBF1-C518-6873-7E9040067DC6
    //参数<1>：int buffer，缓冲区
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getMachineCode(ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getCaptchaImg
    //返回类型：int 
    //函数说明：获取验证码.返回图片本地完整路径
    //参数<1>：int buffer，缓冲区
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getCaptchaImg(ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getFastInfo
    //返回类型：int 
    //函数说明：返回完整快验软件自定义常量
    //参数<1>：int buffer，缓冲区
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getFastInfo(ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getFastPara
    //返回类型：int 
    //函数说明：快速验证通过后,根据提交参数,返回快验自定义常量中指定节点的值,注意,如使用此命令,必须保证快验自定义常量为标准JSON格式,否则请使用hwd_getFastInfo(); 获取数据后自行处理.
    //参数<1>：string name，例 : 软件自定义常量为 {"提交地址":"xxx.com","version":"1.0"},则 : hwd_getFastPara("提交地址"); 返回:xxx.com
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getFastPara(string name, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getUserInfo
    //返回类型：int 
    //函数说明：获取登录用户信息,根据提交参数名,返回指定用户数据.
    //参数<1>：string name，username=用户名,password=密码,state=登录状态,endtime=到期时间,point=点数余额,para=用户自定义数据,bind=用户绑定信息
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getUserInfo(string name, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getUserPara
    //返回类型：int 
    //函数说明：根据提交参数,返回用户自定义常量中指定节点的值,只有用户正常登陆且未到期/有点数,才会返回此值.注意,如使用此命令,必须保证用户自定义常量为标准JSON格式
    //参数<1>：string name，例 : 用户自定义常量为 {"版本":"普通版","高级功能":"ON"},则 : hwd_getUserPara("版本"); 返回:普通版
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getUserPara(string name, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getSoftInfo
    //返回类型：int 
    //函数说明：根据提交参数名,返回网页端设置的软件数据,例如软件名,版本号
    //参数<1>：string name，name=软件名,version=版本号,downloadurl=下载地址,updateurl=更新包地址,notice=客户端公告,qq=客服qq,website=官网地址,loginimg=登录页面图片,para=软件自定义常量(注意,只有登录成功才能取到此值.),captcha=需要验证码的位置(如此值包含 captcha_login 则表示需要登录验证码,如包含 captcha_recharge 则表示需要充值验证码)
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getSoftInfo(string name, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getSoftPara
    //返回类型：int 
    //函数说明：根据提交参数,返回软件自定义常量中指定节点的值,只有用户正常登陆,才会返回此值,如果用户到期,且"允许到期登陆",那么也会返回此值(也属于正常登陆).注意,如使用此命令,必须保证软件自定义常量为标准JSON格式
    //参数<1>：string name，例 : 软件自定义常量为 {"提交地址":"xxx.com","version":"1.0"},则 : hwd_getSoftPara("提交地址"); 返回:xxx.com
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getSoftPara(string name, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getLastErrorCode
    //返回类型：int 
    //函数说明：获取最近一次出错码,如没有出错,返回"200".
    //参数<1>：int buffer，缓冲区
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getLastErrorCode(ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getLastErrorMsg
    //返回类型：int 
    //函数说明：获取最近一次出错信息,如没有出错,返回空.
    //参数<1>：int buffer，缓冲区
    //参数<2>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getLastErrorMsg(ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_getMD5
    //返回类型：int 
    //函数说明：获取文件MD5值
    //参数<1>：string filename，获取MD5值完整文件路径
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_getMD5(string filename, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_init
    //返回类型：bool 
    //函数说明：初始化软件参数,必须最先执行(快验除外).
    //参数<1>：string url，授权域名
    //参数<2>：string webkey，webKey,购买时获得
    //参数<3>：string sid，软件ID,网页后台添加软件后获取
    //参数<4>：string key，通讯秘钥,网页后台添加软件后获取
    //参数<5>：bool loadingWindow，为真时,初始化过程显示等待窗口,避免因网络延迟造成用户体验下降,初始化界面库后有效.
    //参数<6>：int checkDebug，发现调试器后续,0=无操作,1=退出,2=蓝屏,注意,仅在开发模式请设置为0,正式发布一定非零.内核级防调试,近20种反调试手段,设置蓝屏后遇到调试器不一定马上蓝屏,看调试者技术.满足一定条件才会触发蓝屏.
    //参数<7>：int checkVirtualMachine，发现虚拟机运行后续,0=无操作,1=退出,2=蓝屏,一般软件禁止虚拟机运行,防止不法分子使用虚拟机调试.
    //参数<8>：string port，网站端口,可空,默认为80端口.仅支持3种端口号,80,443,999 端口解释:80为http协议,443为https协议,如网站启用https,请使用443端口.999为http指定端口,方便未备案域名使用大陆服务器.
    //参数<9>：bool ui，TRUE:启用界面库,FALSE:不启用界面库,如不启用,所有内置窗口资源均不可用,例如:loading窗口,hwd_loadLoginWindow(),hwd_msgBox(),hwd_msg(),断网重连窗口.等一切内置窗口资源及函数.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_init(string url, string webkey, string sid, string key, bool loadingWindow, int checkDebug, int checkVirtualMachine, string port, bool ui);

    //======================================================
    //函数名称：hwd_heartbeat
    //返回类型：bool 
    //函数说明：心跳包,保持与服务器通讯.请注意,此命令在用户登录成功后必须调用一次,且只需要调用一次. 使用内置窗口登录,无需调用此函数,系统自动调用. 默认通讯时间为180秒.
    //参数<1>：int time，心跳周期,单位:秒,最小120秒,最大300秒,建议180秒左右.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_heartbeat(int time);

    //======================================================
    //函数名称：hwd_msgBox
    //返回类型：int 
    //函数说明：右下角弹出窗口,支持html代码,用于弹出公告、软件提示等.
    //参数<1>：string title，窗口标题
    //参数<2>：string body，弹出内容 支持html代码
    //参数<3>：int keepTime，自动关闭时间 单位:毫秒,为0则不自动关闭.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_msgBox(string title, string body, int keepTime);

    //======================================================
    //函数名称：hwd_closeMsgBox
    //返回类型：bool 
    //函数说明：关闭已弹出的消息,可以在主窗口退出时调用,防止窗口未关闭卡进程.也可以直接结束进程,返回真则关闭成功,返回假则窗口未创建,无需关闭.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_closeMsgBox();

    //======================================================
    //函数名称：hwd_loadLoginWindow
    //返回类型：int 
    //函数说明：载入内置登录窗口,大幅度减少作者开发时间,作者只需专心做功能,重复的工作交给我.使用此命令前必须初始化.
    //参数<1>：string version，本地版本号,如与服务器版本号不同,则调用自动更新程序,如自动更新程序不存在,则打开下载网址.
    //参数<2>：string title，如果为空,则显示软件名.美观起见,标题应在10个汉字内.
    //参数<3>：int noticeTime，公告停留时间,-1:不弹出公告,0:不自动关闭,非0:公告停留时间,单位毫秒.1秒=1000毫秒.
    //参数<4>：string menuItem，加载菜单项,1:官方网站,2:注册账户,3:修改密码,4:账户充值,5:客服QQ,可以组合使用,例如:"12345"或:"1234"
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_loadLoginWindow(string version, string title, int noticeTime, string menuItem);

    //======================================================
    //函数名称：hwd_login
    //返回类型：bool 
    //函数说明：用户登录,如登录失败,请使用 hwd_getLastError();获取失败错误信息.
    //参数<1>：string username，账号密码模式为登录账号,充值卡登录为卡号.
    //参数<2>：string password，账号密码模式为登录密码,充值卡登录无需填写.
    //参数<3>：string code，验证码,如果 hwd_getSoftInfo("captcha") 中包含 "captcha_login" , 则需要填写验证码,否则可留空.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_login(string username, string password, string code);

    //======================================================
    //函数名称：hwd_msg
    //返回类型：int 
    //函数说明：弹出消息框,用户操作后返回点击按钮
    //参数<1>：string title，提示标题
    //参数<2>：string body，提示内容
    //参数<3>：int flags，可以相加后组合使用:0=其他按钮,1=确定按钮,2=取消按钮,4096=应用程序图标,8192=信息图标,16384=询问图标,32768=错误图标,65536=警告图标,131072=盾牌图标
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_msg(string title, string body, int flags);

    //======================================================
    //函数名称：hwd_setUserbind
    //返回类型：bool 
    //函数说明：绑定用户资料,例如配置云备份,绑定游戏号等.用户登录成功状态下,可使用hwd_getUserInfo("bind")获取此绑定资料.
    //参数<1>：string str，欲写入的数据,理论无长度限制,由于数据加密传输,数据越长加密时间越慢,因此不建议数据太大.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_setUserbind(string str);

    //======================================================
    //函数名称：hwd_bindMachineCode
    //返回类型：bool 
    //函数说明：绑定机器码,自动将指定账户绑定本机,无需传入机器码,自动获取,如已达到绑定上限,则删除最先绑定的机器码.转绑扣时扣点自动完成,无需独立扣除.
    //参数<1>：string username，欲绑定的用户名,无需传入机器码,机器码自动获取.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_bindMachineCode(string username);

    //======================================================
    //函数名称：hwd_recharge
    //返回类型：bool 
    //函数说明：用户充值.
    //参数<1>：string user，欲充值的用户名
    //参数<2>：string cardnum，充值卡号
    //参数<3>：string code，验证码,如果 hwd_getSoftInfo("captcha") 中包含 "captcha_recharge" , 则需要填写验证码,否则可留空
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_recharge(string user, string cardnum, string code);

    //======================================================
    //函数名称：hwd_deductPoint
    //返回类型：bool 
    //函数说明：扣点,计点模式可用.
    //参数<1>：int point，扣除点数,最小为1点
    //参数<2>：string remarks，扣点备注,管理可在后台查看,用户可在个人中心查看(请在"系统设置"中开启"记录扣点日志")
    //参数<3>：bool filter，是否过滤,开启后可防止重复扣点(当扣点点数与扣点备注重复时),需在软件后台开启:记录扣点日志.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_deductPoint(int point, string remarks, bool filter);

    //======================================================
    //函数名称：hwd_deductTime
    //返回类型：bool 
    //函数说明：扣时,计时模式可用.
    //参数<1>：int minute，扣时数,单位:分钟,最小为1分钟
    //参数<2>：string remarks，扣时备注,管理可在后台查看,用户可在个人中心查看(请在"系统设置"中开启"记录扣点日志")
    //参数<3>：bool filter，是否过滤,开启后可防止重复扣时(当扣时时间与扣时备注重复时),需在软件后台开启:记录扣点日志.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_deductTime(int minute, string remarks, bool filter);

    //======================================================
    //函数名称：hwd_sleep
    //返回类型：int 
    //函数说明：延时命令,使用此命令不占用CPU,不卡窗口.
    //参数<1>：int times，单位:毫秒,1秒=1000毫秒
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_sleep(int times);

    //======================================================
    //函数名称：hwd_logout
    //返回类型：bool 
    //函数说明：退出登录,程序退出前可调用此命令,服务端立即更新用户状态,否则需要等待无心跳通讯后,才能判定用户退出
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_logout();

    //======================================================
    //函数名称：hwd_exit
    //返回类型：int 
    //函数说明：完全退出,或结束进程.由于内部窗口校验安全通讯,直接销毁软件主窗口会导致内部窗口无法销毁,进而导致用户退出了,进程还在.使用此命令可完全退出.作者也可自行处理.
    //参数<1>：int handle，0=正常退出,1=结束进程.如果有托盘图标,请勿使用结束进程,否则可能导致托盘图标残留,需要用户鼠标滑过图标才会消失
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_exit(int handle);

    //======================================================
    //函数名称：hwd_blueSky
    //返回类型：int 
    //函数说明：蓝色天空,计算机蓝屏.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_blueSky();

    //======================================================
    //函数名称：hwd_getServerTime
    //返回类型：bool 
    //函数说明：取服务器时间,成功返回TRUE,失败返回FALSE.
    //参数<1>：int type，获取类型 为0:10位时间戳[1576117830],为1:日期时间[2019-12-12 10:30:30],返回值不含[]
    //参数<2>：int buffer，缓冲区
    //参数<3>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_getServerTime(int type, ref int buffer, ref int bufferLen);

    //======================================================
    //函数名称：hwd_reg
    //返回类型：bool 
    //函数说明：注册通行证,成功返回true,失败返回false,如果失败可取错误查看失败详情.
    //参数<1>：string username，注册用户名
    //参数<2>：string password，注册密码
    //参数<3>：string email，绑定邮箱,取回密码唯一途径
    //参数<4>：string referrer，推荐人账号,可空
    //参数<5>：string code，验证码,如果 hwd_getSoftInfo("captcha") 中包含 "captcha_reg" , 则需要填写验证码,否则可留空.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_reg(string username, string password, string email, string referrer, string code);

    //======================================================
    //函数名称：hwd_sendMail
    //返回类型：bool 
    //函数说明：发送密码重置邮件,成功返回true,失败返回false,如果失败可取错误查看失败详情.
    //参数<1>：string username，用户名
    //参数<2>：string mail，绑定邮箱
    //参数<3>：string code，验证码,如果 hwd_getSoftInfo("captcha") 中包含 "captcha_repwd" , 则需要填写验证码,否则可留空.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_sendMail(string username, string mail, string code);

    //======================================================
    //函数名称：hwd_resetPwd
    //返回类型：bool 
    //函数说明：修改密码,成功返回true,失败返回false,如果失败可取错误查看失败详情.
    //参数<1>：string username，用户名
    //参数<2>：string password，新密码
    //参数<3>：string mailcode，邮件验证码
    //参数<4>：string code，验证码,如果 hwd_getSoftInfo("captcha") 中包含 "captcha_repwd" , 则需要填写验证码,否则可留空.
    //======================================================
    [DllImport("hwd.dll")]
    public static extern bool hwd_resetPwd(string username, string password, string mailcode, string code);

    //======================================================
    //函数名称：hwd_callPHP
    //返回类型：int 
    //函数说明：动态调用自定义函数(PHP语法)
    //参数<1>：string name，函数名,例如:function test($a,$b){return $a + $b},函数名为:test
    //参数<2>：string para，参数值,例如:function test($a,$b){return $a + $b},参数值为:3,4 参数分隔符为英文半角逗号(,)
    //参数<3>：int buffer，缓冲区
    //参数<4>：int bufferLen，缓冲区尺寸
    //======================================================
    [DllImport("hwd.dll")]
    public static extern int hwd_callPHP(string name, string para, ref int buffer, ref int bufferLen);

}
}
