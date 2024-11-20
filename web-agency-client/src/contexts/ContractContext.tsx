// contexts/ContractContext.tsx
import React, { createContext, useContext, ReactNode } from "react";
import { Contract } from "../types/Contract";
import { useContracts } from "../hooks/useContracts";

interface ContractContextProps {
    contracts: Contract[];
    addContract: (contract: Contract) => void;
    updateContract: (id: number, contract: Contract) => void;
    deleteContract: (id: number) => void;
    refreshContracts: () => void;
}

const ContractContext = createContext<ContractContextProps | undefined>(undefined);

export const ContractProvider = ({ children }: { children: ReactNode }) => {
    const { contracts, addContract, updateContract, deleteContract, refreshContracts } = useContracts();

    return (
        <ContractContext.Provider value={{ contracts, addContract, updateContract, deleteContract, refreshContracts }}>
            {children}
        </ContractContext.Provider>
    );
};

export const useContractContext = () => {
    const context = useContext(ContractContext);
    if (!context) {
        throw new Error("useContractContext must be used within a ContractProvider");
    }
    return context;
};
