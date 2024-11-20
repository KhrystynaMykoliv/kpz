// hooks/useContracts.tsx
import { useState, useEffect } from "react";
import axios from "axios";
import { Contract } from "../types/Contract";

const API_URL = "http://localhost:5228/api/contracts";

export const useContracts = () => {
    const [contracts, setContracts] = useState<Contract[]>([]);

    const fetchContracts = async () => {
        try {
            const response = await axios.get<Contract[]>(API_URL);
            setContracts(response.data);
        } catch (error) {
            console.error("Error fetching contracts:", error);
        }
    };

    useEffect(() => {
        fetchContracts();
    }, []);

    const addContract = async (contract: Contract) => {
        try {
            const response = await axios.post(API_URL, contract);
            setContracts([...contracts, response.data]);
        } catch (error) {
            console.error("Error adding contract:", error);
        }
    };

    const updateContract = async (id: number, updatedContract: Contract) => {
        try {
            const response = await axios.put(`${API_URL}/${id}`, updatedContract);
            setContracts(contracts.map(c => (c.contractCode === id ? response.data : c)));
        } catch (error) {
            console.error("Error updating contract:", error);
        }
    };

    const deleteContract = async (id: number) => {
        try {
            await axios.delete(`${API_URL}/${id}`);
            setContracts(contracts.filter(c => c.contractCode !== id));
        } catch (error) {
            console.error("Error deleting contract:", error);
        }
    };

    const refreshContracts = fetchContracts;

    return {
        contracts,
        addContract,
        updateContract,
        deleteContract,
        refreshContracts,
    };
};
