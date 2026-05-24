namespace LostAndFound
{
    public enum ClaimRequestState
    {
        NeedsItem,
        ActiveClaimExists,
        MissingStudent,
        MissingPhoto,
        Ready
    }

    public sealed class ClaimRequestValidationResult
    {
        public ClaimRequestValidationResult(ClaimRequestState state, string message, bool canSubmit)
        {
            State = state;
            Message = message;
            CanSubmit = canSubmit;
        }

        public ClaimRequestState State { get; private set; }
        public string Message { get; private set; }
        public bool CanSubmit { get; private set; }
    }

    public sealed class ClaimRequestValidator
    {
        public ClaimRequestValidationResult Validate(
            bool hasSelectedItem,
            int activeClaimCount,
            string studentNim,
            string studentName,
            bool hasClaimPhoto)
        {
            if (!hasSelectedItem)
            {
                return new ClaimRequestValidationResult(
                    ClaimRequestState.NeedsItem,
                    "Pilih item found yang akan diklaim.",
                    false);
            }

            if (activeClaimCount > 0)
            {
                return new ClaimRequestValidationResult(
                    ClaimRequestState.ActiveClaimExists,
                    "Item ini sudah punya klaim aktif.",
                    false);
            }

            if (string.IsNullOrWhiteSpace(studentNim) || string.IsNullOrWhiteSpace(studentName))
            {
                return new ClaimRequestValidationResult(
                    ClaimRequestState.MissingStudent,
                    "Isi NIM dan nama lengkap mahasiswa.",
                    false);
            }

            if (!hasClaimPhoto)
            {
                return new ClaimRequestValidationResult(
                    ClaimRequestState.MissingPhoto,
                    "Upload foto klaim atau pakai foto kamera.",
                    false);
            }

            return new ClaimRequestValidationResult(
                ClaimRequestState.Ready,
                "Siap menyetujui klaim dan mengembalikan item.",
                true);
        }
    }
}
