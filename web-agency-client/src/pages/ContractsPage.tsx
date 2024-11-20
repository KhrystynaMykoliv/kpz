import { useState } from "react";
import { Contract } from "../types/Contract.tsx";
import { useContractContext } from "../contexts/ContractContext.tsx";
import FlashMessage from "../components/UIKits/FlashMessage.tsx";
import ContractsForm from "../components/Contracts/ContractsForm.tsx";
import ContractsTable from "../components/Contracts/ContractsTable.tsx";

const ContractsPage: React.FC = () => {
    const [newContract, setNewContract] = useState<Contract>({
        contractCode: 0,
        dateDesigned: new Date(),
        validFrom: new Date(),
        validTo: new Date(),
        managerId: 0,
        clientId: 0,
        managerName: "",
        clientCompanyName: ""
    });

    const { addContract } = useContractContext();
    const [flashMessage, setFlashMessage] = useState<boolean>(false);

    const onCloseFlash = () => {
        setFlashMessage(false);
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        addContract(newContract);
        setNewContract({
            contractCode: 0,
            dateDesigned: new Date(),
            validFrom: new Date(),
            validTo: new Date(),
            managerId: 0,
            clientId: 0,
            managerName: "",
            clientCompanyName: ""
        });
        setFlashMessage(true);
    };

    return (
        <div className="container">
            <div className="flex">
                <h1>Contracts</h1>
            </div>
            <ContractsForm
                contractData={newContract}
                handleSubmit={handleSubmit}
                setContractData={setNewContract}
            />
            <div className="flex">
                <ContractsTable />
            </div>
            {flashMessage && (
                <FlashMessage
                    title="Contract successfully created!"
                    onClose={onCloseFlash}
                    timeout={3000}
                />
            )}
        </div>
    );
};

export default ContractsPage;
