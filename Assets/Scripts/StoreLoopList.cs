using UnityEngine;
using FairyGUI;

public class StoreLoopList : MonoBehaviour
{
    GComponent _mainView;
    GList _list;
    private StoreSelect storeSelect;
    public MyStoreObj myStoreObj;

    [Header("企劃自訂義的資源供給量係數---糖郊")]
    public float surStore_refCoefficient;
    [Header("企劃自訂義的資源供給量係數---南郊")]
    public float medStore_refCoefficient;
    [Header("企劃自訂義的資源供給量係數---北郊")]
    public float cloStore_refCoefficient;



    void Start()
    {
        storeSelect = GameObject.Find("StoreSelect(Canvas)").GetComponent<StoreSelect>();

        Application.targetFrameRate = 60;
        Stage.inst.onKeyDown.Add(OnKeyDown);

        UIPackage.AddPackage("fgui_package/StoreSelectPackage");

        _mainView = this.GetComponent<UIPanel>().ui;

        _list = _mainView.GetChild("list").asList;
        _list.SetVirtualAndLoop();

        _list.itemRenderer = RenderListItem;
        _list.numItems = 3;
        _list.scrollPane.onScroll.Add(DoSpecialEffect);

        DoSpecialEffect();
    }

    void DoSpecialEffect()
    {
        //change the scale according to the distance to middle
        float listCenter = _list.scrollPane.posX + _list.viewWidth / 2;
        int cnt = _list.numChildren;
        for (int i = 0; i < cnt; i++)
        {
            GObject item = _list.GetChildAt(i);
            float itemCenter = item.x + item.width / 2;
            float itemWidth = item.width;
            float distance = Mathf.Abs(listCenter - itemCenter);
            if (distance < itemWidth) //no intersection
            {
                //float distanceRange = 1 + (1 - distance / itemWidth) * 0.02f;//選取大小幅度
                item.SetScale(1, 1);
            }     
            else
            {
                item.SetScale(1, 1);
            }
        }
        //Debug.Log(_list.GetFirstChildInView());

        switch (_list.GetFirstChildInView() + 1)
        {
            case 1:
                storeSelect.SurStore();
                myStoreObj.kindOfStore = "糖郊";
                myStoreObj.kindOfStoret_refCoefficient = surStore_refCoefficient;
                break;
            case 2:
                storeSelect.MedStore();
                myStoreObj.kindOfStore = "南郊";
                myStoreObj.kindOfStoret_refCoefficient = medStore_refCoefficient;
                break;
            case 3:
                storeSelect.CloStore();
                myStoreObj.kindOfStore = "北郊";
                myStoreObj.kindOfStoret_refCoefficient = cloStore_refCoefficient;
                break;
            default:
                break;
        }
    }

    void RenderListItem(int index, GObject obj)
    {
        GButton item = (GButton)obj;
        item.SetPivot(0.5f, 0.5f);
        item.icon = UIPackage.GetItemURL("StoreSelectPackage", "n" + (index + 1));
    }

    void OnKeyDown(EventContext context)
    {
        if (context.inputEvent.keyCode == KeyCode.Escape)
        {
            Application.Quit();
        }
    }
}