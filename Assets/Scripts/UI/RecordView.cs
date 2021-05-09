﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class RecordView : MonoBehaviour {

        [SerializeField]
        private Text _placeLabel;

        [SerializeField]
        private Text _dateLabel;

        [SerializeField]
        private Text _scoreLabel;

        [SerializeField]
        private Image _imageNewRecord;

        public void SetData(int place, string date, string score, bool isNewRecord) {
            _placeLabel.text = $"{place}";
            _dateLabel.text = date;
            _scoreLabel.text = score;
            _imageNewRecord.enabled = isNewRecord;
        }
    }
}
