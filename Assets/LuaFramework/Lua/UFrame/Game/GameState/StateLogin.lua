StateLogin = {}
function StateLogin:Enter()
    print("lua StateLogin Enter")
    --加载Login场景
    --ResHelper.LoadScene("scenes/login")
    --SceneManagement.GetInstance():LoadScene("scenes/login", 
    --    function ()
    --        print("load scenes/login callback++++++++++++++++")
    --        local gogetter = ResHelper.LoadGameObject("prefabs/cube")
    --        local cubeGo = gogetter:Get()
    --        local assetgetterBlue = ResHelper.LoadAsset("materials/blue")
    --        local mBlue = assetgetterBlue:Get(cubeGo)
    --        cubeGo:GetComponent("Renderer").material = mBlue
    --        --打开Login的UI
    --        print("lua open login ui")
    --        EventManager.Instance():DispatchEvent(MessageCode.UIMsg_CreateUI, Enum_UINameDefine.UI_Login)
    --    end)
    
    print("lua open login ui")
    EventManager.Instance():DispatchEvent(MessageCode.UIMsg_CreateUI, Enum_UINameDefine.UI_Login)
end

function StateLogin:Leave()
    --SceneManagement.GetInstance():UnLoadScene()
end


--Class = require("UFrame/Core/middleclass")
--StateLogin = Class.class('StateLogin')
--
--function StateLogin.Enter()
--    print("lua StateLogin Enter")
--end
--
--StateLogin = StateLogin:new()







