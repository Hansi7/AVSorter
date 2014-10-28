using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVSORTER
{
    public enum QStatus
    {
        未开始,//未开始
        查询中,//查询列表
        查询完成一个结果,//列表完成
        查询完成无匹配,
        多个结果请选择一个,
        获取信息中,//获取详细中
        获取信息完成,//获取详细完毕
        下载封面中,//获取封面
        封面下载完成,//获取封面完毕
        准备好移动文件,//完成
        出错//出错
    }
}
