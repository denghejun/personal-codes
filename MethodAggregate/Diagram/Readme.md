Runner
1.提供重试Command机制
2.提供后台存贮Json，采用【GUID，JsonContent】，无限分间隔重试机制
3.提供失败邮件处理机制
4.提供同步和异步重试

Command
1. 新增 ：失败的Hook，WhenError， 默认：throw;