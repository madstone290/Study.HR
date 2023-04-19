/**
 * AntD Menu컴포넌트에 등록할 아이템 정보
 */
export class ItemInfo {
    key;
    label;
    icon;
    children;
    type;
    constructor(key, label, icon, children, type){
        this.key = key;
        this.label = label;
        this.icon = icon;
        this.children = children;
        this.type = type;
    }
}