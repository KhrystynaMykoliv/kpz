import React, { useEffect, useState } from "react";
import { useContractContext } from "../contexts/ContractContext";
import { useNavigate, useParams } from "react-router-dom";
import { Contract } from "../types/Contract";
import ContractsForm from "../components/Contracts/ContractsForm.tsx";

const EditContractsPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const { contracts, updateContract } = useContractContext();
    const navigate = useNavigate();

    const contractToEdit = contracts.find(contract => contract.contractCode === Number(id));

    const [contractData, setContractData] = useState<Contract>({
        contractCode: 0,
        dateDesigned: new Date(),
        validFrom: new Date(),
        validTo: new Date(),
        managerId: 0,
        clientId: 0,
        managerName: "",
        clientCompanyName: ""
    });

    useEffect(() => {
        if (contractToEdit) {
            setContractData(contractToEdit);
        }
    }, [contractToEdit]);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (contractData) {
            updateContract(contractData.contractCode, contractData);
            navigate("/contracts");
        }
    };

    if (!contractData) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Edit Contract</h1>
            <ContractsForm
                contractData={contractData}
                setContractData={setContractData}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default EditContractsPage;
