import React from "react";
import Label from "../UIKits/Label";
import Input from "../UIKits/Input";
import Button from "../UIKits/Button";
import { Contract } from "../../types/Contract";
import { useManagerContext } from "../../contexts/ManagerContext";
import { useClientContext } from "../../contexts/ClientContext";

interface ContractFormProps {
    contractData: Contract;
    setContractData: React.Dispatch<React.SetStateAction<Contract>>;
    handleSubmit: (e: React.FormEvent) => void;
}

const ContractForm: React.FC<ContractFormProps> = ({ contractData, setContractData, handleSubmit }) => {
    const { managers } = useManagerContext();
    const { clients } = useClientContext();

    const formatDate = (date: Date | string | null | undefined): string => {
        if (!date) return "";
        const parsedDate = date instanceof Date ? date : new Date(date);
        if (isNaN(parsedDate.getTime())) return "";
        return parsedDate.toISOString().split("T")[0];
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Date Designed" id="contract_date_designed" />
                    <Input
                        id="contract_date_designed"
                        type="date"
                        placeholder="Date designed..."
                        value={formatDate(contractData.dateDesigned)}
                        onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
                            setContractData(prevState => ({
                                ...prevState,
                                dateDesigned: new Date(e.target.value),
                            }));
                        }}
                        required
                    />
                </div>
                <div className="form-control">
                    <Label text="Valid From" id="contract_valid_from" />
                    <Input
                        id="contract_valid_from"
                        type="date"
                        placeholder="Valid from..."
                        value={formatDate(contractData.validFrom)} // Format Date to "YYYY-MM-DD"
                        onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
                            setContractData(prevState => ({
                                ...prevState,
                                validFrom: new Date(e.target.value), // Parse back to Date
                            }));
                        }}
                        required
                    />
                </div>
            </div>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Valid To" id="contract_valid_to" />
                    <Input
                        id="contract_valid_to"
                        type="date"
                        placeholder="Valid to..."
                        value={formatDate(contractData.validTo)} // Format Date to "YYYY-MM-DD"
                        onChange={(e) =>
                            setContractData(prevState => ({
                                ...prevState,
                                validTo: new Date(e.target.value), // Parse back to Date
                            }))
                        }
                        required
                    />
                </div>
                <div className="form-control">
                    <Label text="Manager" id="contract_manager_id" />
                    <select
                        id="contract_manager_id"
                        value={contractData.managerId}
                        onChange={(e) =>
                            setContractData(prevState => ({
                                ...prevState,
                                managerId: Number(e.target.value),
                            }))
                        }
                        required
                    >
                        <option value="">Select a manager...</option>
                        {managers.map(manager => (
                            <option key={manager.personId} value={manager.personId}>
                                {`${manager.person.firstName} ${manager.person.lastName}`}
                            </option>
                        ))}
                    </select>
                </div>
            </div>
            <div className="form-flex">
                <div className="form-control">
                    <Label text="Client" id="contract_client_id" />
                    <select
                        id="contract_client_id"
                        value={contractData.clientId}
                        onChange={(e) =>
                            setContractData(prevState => ({
                                ...prevState,
                                clientId: Number(e.target.value),
                            }))
                        }
                        required
                    >
                        <option value="">Select a client...</option>
                        {clients.map(client => (
                            <option key={client.personId} value={client.personId}>
                                {client.companyName}
                            </option>
                        ))}
                    </select>
                </div>
            </div>
            <Button text="Submit" color="blue" />
        </form>
    );
};

export default ContractForm;
