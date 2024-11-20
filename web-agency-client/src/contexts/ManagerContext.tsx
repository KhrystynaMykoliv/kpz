import React, { createContext, useContext, ReactNode } from "react";
import { Manager } from "../types/Manager.tsx";
import { useManagers } from "../hooks/UseManagers.tsx";

interface ManagerContextProps {
    managers: Manager[];
    addManager: (manager: Manager) => void;
    updateManager: (id: number, manager: Manager) => void;
    deleteManager: (id: number) => void;
    refreshManagers: () => void;
}

const ManagerContext = createContext<ManagerContextProps | undefined>(undefined);

export const ManagerProvider = ({ children }: { children: ReactNode }) => {
    const { managers, addManager, updateManager, deleteManager, refreshManagers } = useManagers();

    console.log(managers);
    return (
        <ManagerContext.Provider value={{ managers, addManager, updateManager, deleteManager, refreshManagers }}>
            {children}
        </ManagerContext.Provider>
    );
};

export const useManagerContext = () => {
    const context = useContext(ManagerContext);
    if (!context) {
        throw new Error("useManagerContext must be used within a ManagerProvider");
    }
    return context;
};
