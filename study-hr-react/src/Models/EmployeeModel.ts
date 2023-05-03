export class EmployeeModel {
    [prop: string]: any;


    static empty() {
        return new EmployeeModel();
    }

    static new(id: number, name: string, age: number) {
        const emp = new EmployeeModel();
        emp.key = id;
        emp.id = id;
        emp.name = name;
        emp.age = age;
        return emp;
    }
}

export const SalaryType = {
    Monthly: "Monthly",
    Weekly: "Weekly",
    Hourly: "Hourly",
};
Object.freeze(SalaryType);


export const employeeList = [
    EmployeeModel.new(1, "John", 30),
    EmployeeModel.new(2, "Bruce", 38),
    EmployeeModel.new(3, "Alex", 22),
    EmployeeModel.new(4, "Susan", 31),
    EmployeeModel.new(5, "Lyn", 35),
    EmployeeModel.new(6, "Sally", 23),
    EmployeeModel.new(7, "Lina", 34),
    EmployeeModel.new(8, "Mundo", 20),
    EmployeeModel.new(9, "김이박", 20),
    EmployeeModel.new(10, "수박", 30),
    EmployeeModel.new(11, "John", 30),
    EmployeeModel.new(12, "Bruce", 38),
    EmployeeModel.new(13, "Alex", 22),
    EmployeeModel.new(14, "Susan", 31),
    EmployeeModel.new(15, "Lyn", 35),
    EmployeeModel.new(16, "Sally", 23),
    EmployeeModel.new(17, "Lina", 34),
    EmployeeModel.new(18, "Mundo", 20),
    EmployeeModel.new(19, "김이박", 20),
    EmployeeModel.new(20, "김박", 30),
    EmployeeModel.new(21, "John", 30),
    EmployeeModel.new(22, "Bruce", 38),
    EmployeeModel.new(23, "Alex", 22),
    EmployeeModel.new(24, "Susan", 31),
    EmployeeModel.new(25, "Lyn", 35),
    EmployeeModel.new(26, "Sally", 23),
    EmployeeModel.new(27, "Lina", 34),
    EmployeeModel.new(28, "Mundo", 20),
    EmployeeModel.new(29, "김이박", 20),
];