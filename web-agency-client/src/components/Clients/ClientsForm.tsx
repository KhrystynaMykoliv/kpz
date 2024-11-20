import React from "react";
import Label from "../UIKits/Label.tsx";
import Input from "../UIKits/Input.tsx";
import Button from "../UIKits/Button.tsx";
import { Client } from "../../types/Client.tsx";

interface ClientFormProps {
    clientData: Client;
    setClientData: React.Dispatch<React.SetStateAction<Client>>;
    handleSubmit: (e: React.FormEvent) => void;
}

const ClientForm: React.FC<ClientFormProps> = ({ clientData, setClientData, handleSubmit }) => {
    return (
        <form onSubmit={handleSubmit}>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Company Name" id="client_company_name" />
                    <Input
                        id="client_company_name"
                        type="text"
                        placeholder="Company name..."
                        value={clientData.companyName}
                        onChange={(e) =>
                            setClientData(prevState => ({
                                ...prevState,
                                companyName: e.target.value
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
                        value={clientData.person.firstName}
                        onChange={(e) =>
                            setClientData(prevState => ({
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
                        value={clientData.person.lastName}
                        onChange={(e) =>
                            setClientData(prevState => ({
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
                        value={clientData.person.email}
                        onChange={(e) =>
                            setClientData(prevState => ({
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
                        value={clientData.person.phone}
                        onChange={(e) =>
                            setClientData(prevState => ({
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

export default ClientForm;
