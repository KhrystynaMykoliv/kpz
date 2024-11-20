import React, { createContext, useContext, ReactNode } from "react";
import { Client } from "../Types/Client";
import { useClients } from "../Hooks/UseClients.tsx";

interface ClientContextProps {
    clients: Client[];
    addClient: (client: Client) => void;
    updateClient: (id: number, client: Client) => void;
    deleteClient: (id: number) => void;
    refreshClients: () => void;
}

const ClientContext = createContext<ClientContextProps | undefined>(undefined);

export const ClientProvider = ({ children }: { children: ReactNode }) => {
    const { clients, addClient, updateClient, deleteClient, refreshClients } = useClients();

    console.log(clients);
    return (
        <ClientContext.Provider value={{ clients, addClient, updateClient, deleteClient, refreshClients }}>
            {children}
        </ClientContext.Provider>
    );
};

export const useClientContext = () => {
    const context = useContext(ClientContext);
    if (!context) {
        throw new Error("useClientContext must be used within a ClientProvider");
    }
    return context;
};
