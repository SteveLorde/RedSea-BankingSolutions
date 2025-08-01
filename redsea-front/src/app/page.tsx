"use client";

import "./app.scss";
import { useState } from "react";

export default async function Page() {
  const [passedIdStage, setPassedIdStage] = useState<boolean>(false);

  return (
    <div className={"loginLayout"}>
      {/* 3D Scene Section, No functionality*/}
      <section>{!passedIdStage && <UserThreeIcon />}</section>
      {/* Sequential Login Panel*/}
      <section>
        {!passedIdStage && (
          <form action={() => {}}>
            <input type={"text"} placeholder={"Account Id..."} />
            <button type={"submit"}>Submit</button>
          </form>
        )}
        {passedIdStage && (
          <div>
            <form action={() => {}}>
              <input type={"text"} placeholder={"Account Id..."} />
              <button type={"submit"}>Submit</button>
            </form>
          </div>
        )}
      </section>
    </div>
  );
}
