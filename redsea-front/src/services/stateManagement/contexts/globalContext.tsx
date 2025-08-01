"use client";

import { createContext, useContext, useState } from "react";

interface globalContextType {
  activeDashboardTab: number;
  ChangeActiveDashboardTab: (tab: number) => void;
}

const GlobalContext = createContext<globalContextType>({
  activeDashboardTab: 0,
  ChangeActiveDashboardTab: () => {},
});

export function useGlobalContext() {
  const context = useContext(GlobalContext);
  return context;
}

export function GlobalContextProvider({ children }: { children: React.ReactNode }) {
  const [activeDashboardTab, setActiveDashboardTab] = useState<number>(0);

  function ChangeActiveDashboardTab(tab: number) {
    setActiveDashboardTab(tab);
  }

  return (
    <GlobalContext.Provider value={{ activeDashboardTab, ChangeActiveDashboardTab }}>
      {children}
    </GlobalContext.Provider>
  );
}
