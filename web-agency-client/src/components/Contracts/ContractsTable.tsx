import React, { useState } from "react";
import { Contract } from "../../types/Contract";
import { useContractContext } from "../../contexts/ContractContext";
import Button from "../UIKits/Button";
import ModalWindow from "../UIKits/ModalWindow";

const ContractsTable: React.FC = () => {
    const { contracts, deleteContract } = useContractContext();
    const [deleteWindow, setDeleteWindow] = useState<boolean>(false);
    const [selectedContract, setSelectedContract] = useState<Contract | null>(null);

    const openDeleteWindow = (contract: Contract) => {
        setSelectedContract(contract);
        setDeleteWindow(true);
    };

    const closeDeleteWindow = () => {
        setDeleteWindow(false);
        setSelectedContract(null);
    };

    const confirmDelete = () => {
        if (selectedContract) {
            deleteContract(selectedContract.contractCode);
            closeDeleteWindow();
        }
    };

    return (
        <div>
            <table>
                <thead>
                <tr>
                    <th>Contract Code</th>
                    <th>Date Designed</th>
                    <th>Valid From</th>
                    <th>Valid To</th>
                    <th>Manager Name</th>
                    <th>Client Company Name</th>
                    <th className="actions">Actions</th>
                </tr>
                </thead>
                <tbody>
                {contracts.map((contract) => (
                    <tr key={contract.contractCode}>
                        <td>{contract.contractCode}</td>
                        <td>{new Date(contract.dateDesigned).toLocaleDateString()}</td>
                        <td>{new Date(contract.validFrom).toLocaleDateString()}</td>
                        <td>{new Date(contract.validTo).toLocaleDateString()}</td>
                        <td>{contract.managerName || "N/A"}</td>
                        <td>{contract.clientCompanyName || "N/A"}</td>
                        <td className="actions">
                            <Button
                                text="Edit"
                                color="gray"
                                link={true}
                                to={`/contracts/edit/${contract.contractCode}`}
                            />
                            <Button
                                text="Delete"
                                color="red"
                                onClick={() => openDeleteWindow(contract)}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
            {deleteWindow && (
                <ModalWindow
                    opened={deleteWindow}
                    onClose={closeDeleteWindow}
                    title="Are you sure?"
                    onSubmit={confirmDelete}
                >
                    <p>Contract data will be permanently deleted!</p>
                </ModalWindow>
            )}
        </div>
    );
};

export default ContractsTable;
