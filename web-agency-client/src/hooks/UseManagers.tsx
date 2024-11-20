import { useState, useEffect } from "react";
import axios from "axios";
import { Manager } from "../types/Manager";

const API_URL = "http://localhost:5228/api/managers";

export const useManagers = () => {
    const [managers, setManagers] = useState<Manager[]>([]);

    const fetchManagers = async () => {
        try {
            const response = await axios.get<Manager[]>(API_URL);
            setManagers(response.data);
        } catch (error) {
            console.error("Error fetching managers:", error);
        }
    };

    useEffect(() => {
        fetchManagers();
    }, []);

    const addManager = async (manager: Manager) => {
        try {
            const response = await axios.post(API_URL, manager);
            setManagers([...managers, response.data]);
        } catch (error) {
            console.error("Error adding manager:", error);
        }
    };

    const updateManager = async (id: number, updatedManager: Manager) => {
        try {
            const response = await axios.put(`${API_URL}/${id}`, updatedManager);
            setManagers(managers.map((m) => (m.personId === id ? response.data : m)));
        } catch (error) {
            console.error("Error updating manager:", error);
        }
    };

    const deleteManager = async (id: number) => {
        try {
            await axios.delete(`${API_URL}/${id}`);
            setManagers(managers.filter((m) => m.personId !== id));
        } catch (error) {
            console.error("Error deleting manager:", error);
        }
    };

    const refreshManagers = fetchManagers;

    return {
        managers,
        addManager,
        updateManager,
        deleteManager,
        refreshManagers,
    };
};
