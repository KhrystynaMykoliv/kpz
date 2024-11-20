import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ClientsPage from "./pages/ClientsPage.tsx";
import {ClientProvider} from "./contexts/ClientContext.tsx";
import Header from "./components/Layouts/Header.tsx";
import EditClientsPage from "./pages/EditClientsPage.tsx";
import {ManagerProvider} from "./contexts/ManagerContext.tsx";
import EditManagersPage from "./pages/EditManagersPage.tsx";
import ManagersPage from "./pages/ManagersPage.tsx";
import {ContractProvider} from "./contexts/ContractContext.tsx";
import ContractsPage from "./pages/ContractsPage.tsx";
import EditContractsPage from "./pages/EditContractsPage.tsx";

function App() {
    return (
        <ClientProvider>
            <ContractProvider>
                <ManagerProvider>
                    <BrowserRouter>
                        <Header />
                        <Routes>
                            <Route path={"/"} element={<ClientsPage />} />
                            <Route path={"/clients/edit/:id"} element={<EditClientsPage />} />
                            <Route path={"/managers"} element={<ManagersPage />} />
                            <Route path={"/managers/edit/:id"} element={<EditManagersPage />} />
                            <Route path={"/contracts"} element={<ContractsPage />} />
                            <Route path={"/contracts/edit/:id"} element={<EditContractsPage />} />
                        </Routes>
                    </BrowserRouter>
                </ManagerProvider>
            </ContractProvider>
        </ClientProvider>
    );
}

export default App;
