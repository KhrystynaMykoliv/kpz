import { Person } from './Person.tsx';

export interface Client {
    personId: number,
    companyName: string,
    person: Person
}