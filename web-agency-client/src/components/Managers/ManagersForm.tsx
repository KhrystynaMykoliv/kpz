import React from "react";
import Label from "../UIKits/Label.tsx";
import Input from "../UIKits/Input.tsx";
import Button from "../UIKits/Button.tsx";
import { Manager } from "../../types/Manager.tsx";

interface ManagerFormProps {
    managerData: Manager;
    setManagerData: React.Dispatch<React.SetStateAction<Manager>>;
    handleSubmit: (e: React.FormEvent) => void;
}

const ManagersForm: React.FC<ManagerFormProps> = ({ managerData, setManagerData, handleSubmit }) => {
    return (
        <form onSubmit={handleSubmit}>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Started Work" id="manager_started_work" />
                    <Input
                        id="manager_started_work"
                        type="date"
                        placeholder="Started work date..."
                        value={new Date(managerData.startedWork).toISOString().split("T")[0]} // Format date for input
                        onChange={(e) =>
                            setManagerData(prevState => ({
                                ...prevState,
                                startedWork: new Date(e.target.value)
                            }))
                        }
                        required
                    />
                </div>
            </div>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="First Name" id="person_first_name" />
                    <Input
                        id="person_first_name"
                        type="text"
                        placeholder="First name..."
                        value={managerData.person.firstName}
                        onChange={(e) =>
                            setManagerData(prevState => ({
                                ...prevState,
                                person: {
                                    ...prevState.person,
                                    firstName: e.target.value
                                }
                            }))
                        }
                        required
                    />
                </div>
                <div className="form-control">
                    <Label text="Last Name" id="person_last_name" />
                    <Input
                        id="person_last_name"
                        type="text"
                        placeholder="Last name..."
                        value={managerData.person.lastName}
                        onChange={(e) =>
                            setManagerData(prevState => ({
                                ...prevState,
                                person: {
                                    ...prevState.person,
                                    lastName: e.target.value
                                }
                            }))
                        }
                        required
                    />
                </div>
            </div>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Email" id="person_email" />
                    <Input
                        id="person_email"
                        type="email"
                        placeholder="Email..."
                        value={managerData.person.email}
                        onChange={(e) =>
                            setManagerData(prevState => ({
                                ...prevState,
                                person: {
                                    ...prevState.person,
                                    email: e.target.value
                                }
                            }))
                        }
                        required
                    />
                </div>
                <div className="form-control">
                    <Label text="Phone Number" id="person_phone" />
                    <Input
                        id="person_phone"
                        type="text"
                        placeholder="Phone number..."
                        value={managerData.person.phone}
                        onChange={(e) =>
                            setManagerData(prevState => ({
                                ...prevState,
                                person: {
                                    ...prevState.person,
                                    phone: e.target.value
                                }
                            }))
                        }
                        required
                    />
                </div>
            </div>
            <Button text="Submit" color="blue" />
        </form>
    );
};

export default ManagersForm;
