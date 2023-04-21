export class Department{
    key = 0;
    id = 0;
    code ="";
    name = "";
    upperDepartmentId = null;


    static fromJson(json) {
        const dept = new Department();
        dept.key = json.id;
        dept.id = json.id;
        dept.code = json.code;
        dept.name = json.name;
        dept.upperDepartmentId = json.upperDepartmentId;

        return dept;
    }
}