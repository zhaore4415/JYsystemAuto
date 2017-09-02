function GetJobStatus(status, Verified) { 
    var result = null;
    switch (Verified)
    {
        case "-1":
            result = "<span class='deleted'>不通过</span>";
            break;
        case "0":
            result = "<span class='deleted'>待审核</span>";
            break;
        case "1":
            switch (status) {
                case "-1":
                    result = "<span class='deleted'>已删除</span>";
                    break;
                case "0":
                    result = "<span class='hidden'>已隐藏</span>";
                    break;
                case "1":
                    result = "<span class='published'>已发布</span>";
                    break;
            }
            break;
    }
    return result;
}