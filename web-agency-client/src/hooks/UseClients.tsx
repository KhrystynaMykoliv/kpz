import { useState, useEffect } from "react";
import axios from "axios";
import { Client } from "../Types/Client";

const API_URL = "http://localhost:5228/api/clients";

export const useClients = () => {
    const [clients, setClients] = useState<Client[]>([]);

    const fetchClients = async () => {
        try {
            const response = await axios.get<Client[]>(API_URL);
            setClients(response.data);
        } catch (error) {
            console.error("Error fetching clients:", error);
        }
    };

    useEffect(() => {
        fetchClients();
    }, []);

    const addClient = async (client: Client) => {
        try {
            const response = await axios.post(API_URL, client);
            setClients([...clients, response.data]);
        } catch (error) {
            console.error("Error adding client:", error);
        }
    };

    const updateClient = async (id: number, updatedClient: Client) => {
        try {
            const response = await axios.put(`${API_URL}/${id}`, updatedClient);
            setClients(clients.map((c) => (c.personId === id ? response.data : c)));
        } catch (error) {
            console.error("Error updating client:", error);
        }
    };

    const deleteClient = async (id: number) => {
        try {
            await axios.delete(`${API_URL}/${id}`);
            setClients(clients.filter((c) => c.personId !== id));
        } catch (error) {
            console.error("Error deleting client:", error);
        }
    };

    const refreshClients = fetchClients;

    return {
        clients,
        addClient,
        updateClient,
        deleteClient,
        refreshClients,
    };
};