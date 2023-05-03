import { baseApi } from "Services/Api/Common/BaseApi";
import { JsonMapper, TextMapper } from "Services/Api/Common/ContentMapper";

const route = "department";

export class DepartmentDto {
    id!: number;
    code!: string;
    name!: string;
    upperDepartmentId?: number;
}

export class DepartmentApi {
    getDepartments() {
        return baseApi.get<DepartmentDto[]>(route, new JsonMapper<DepartmentDto[]>());
    }

    addDepartment(department: DepartmentDto) {
        return baseApi.post(route, department, new TextMapper<number>((text) => parseInt(text)));
    }

    updateDepartment(id: number, department: DepartmentDto) {
        return baseApi.put(`department/${id}`, department);
    }

    deleteDepartment(id: number) {
        return baseApi.delete(`department/${id}`);
    }
}