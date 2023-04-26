export class AntColumnProps {
    constructor({ title = "", dataIndex = "", render = (value) => { }}) {
        this.title = title;
        this.dataIndex = dataIndex;
        this.render = render;
    }
}