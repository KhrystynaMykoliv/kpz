import { Person } from './Person.tsx';

export interface Manager {
    personId: number,
    startedWork: Date,
    person: Person
}