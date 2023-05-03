import { baseApi } from "Services/Api/Common/BaseApi";
import { JsonMapper, TextMapper } from "Services/Api/Common/ContentMapper";

const route = "Employee";

export class EmployeeDto {
    id!: number;
    code!: string;
    name!: string;
    address?: string;
    email?: string;
    phoneNumber?: string;
    phoneNumberHead?: string;
    phoneNumberBody?: string
    loginId?: string;
    loginPassword?: string;
    desc?: string;

    salaryType?: string;
}

export class EmployeeApi {
    getEmployees() {
        return baseApi.get(route, new JsonMapper<EmployeeDto[]>());
    }

    addEmployee(employee: EmployeeDto) {
        return baseApi.post(route, employee, new TextMapper<number>((text) => parseInt(text)));
    }

    updateEmployee(id: number, employee: EmployeeDto) {
        return baseApi.put(`${route}/${id}`, employee);
    }

    deleteEmployee(id: number) {
        return baseApi.delete(`${route}/${id}`);
    }
}