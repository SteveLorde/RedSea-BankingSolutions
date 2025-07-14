"use client";
import "./totalMoneyChartDonut.scss";
import { useState } from "react";

export interface chartMoneyElements {
  title: string;
  value: number;
}

export function TotalMoneyChartDonut({
  totalMoney,
  chartMoneyElements,
}: {
  totalMoney: number;
  chartMoneyElements: chartMoneyElements[];
}) {
  const [segmentIndexToDisplay, setSegmentIndexToDisplay] = useState<number>(0);

  function hoverSelectSegment(index: number) {
    setSegmentIndexToDisplay(index);
  }

  return (
    <>
      <svg className={"donut"} width={"100%"} height={"100%"}>
        <circle className={"donut-hole"} cx={"21"} cy={"21"} r={"20"} fill={"#fff"}></circle>
        <circle className={"donut-ring"} cx={"21"} cy={"21"} r={"20"}></circle>
        <circle className={"donut-segment"} cx={"21"} cy={"21"} r={"20"}></circle>
        <g className="donut-text">
          {segmentIndexToDisplay == 0 && (
            <div>
              <text x="50%" y="50%" className="donut-text-label">
                Total
              </text>
              <text x="50%" y="50%" className="donut-text-value"></text>
            </div>
          )}
          {segmentIndexToDisplay !== 0 && (
            <div>
              <text x="50%" y="50%" className="donut-text-label">
                {chartMoneyElements[segmentIndexToDisplay].title}
              </text>
              <text x="50%" y="50%" className="donut-text-value">
                {chartMoneyElements[segmentIndexToDisplay].value}
              </text>
            </div>
          )}
        </g>
      </svg>
    </>
  );
}
