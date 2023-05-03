export class DepartmentModel {
    [prop: string]: any;
    key: number;
    id: number;
    code: string;
    name: string;
    upperDepartmentId?: number;
    constructor(id: number, code: string, name: string) {
        this.key = id;
        this.id = id;
        this.code = code;
        this.name = name;
    }

    static empty(){
        return new DepartmentModel(0, "", "");
    }
}