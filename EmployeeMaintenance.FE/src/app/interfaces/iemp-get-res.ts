export interface Iemp {
    employeeId: string;
    employedDate:Date,
    employeeNum:string,
    firstName:string,
    lastName:string,
    terminatedDate:Date
    birthDate: Date
}

export interface IempList {
    employees: Iemp[]
}
