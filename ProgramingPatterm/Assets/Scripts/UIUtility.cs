/// <summary>
/// �ǂ̃N���X����ł��Ăяo�����{�I�ȏ����B
/// static���g�p���Ă邽�߁A�ǂ̃N���X����ł��A�N�Z�X�ł���B
/// 
/// static�ŃN���X���쐬����B
/// ����ɂ���ăC���X�^���X���������Ă��Ȃ��Ă��N���X�ɃA�N�Z�X�ł���悤�ɂȂ�B
/// </summary>
public static class UIUtility
{
    //���\�b�h��static�ō쐬����B
    //����ɂ���ăC���X�^���X���������Ă��Ȃ��Ă����\�b�h�ɃA�N�Z�X�ł���悤�ɂȂ�B

    /// <summary>
    /// 3�����ƂɁu,�v������������𐶐�����
    /// </summary>
    public static string NumberFormatter(int number)
    {
        return number.ToString("#,0");
    }

    /// <summary>
    /// ���l���p�[�Z���g�\���ɕύX(������Q�ʂ܂�)
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        float convertRatio = ratio * 100.0f;
        return convertRatio.ToString("F2") + "%";
    }
}

//��Ȏg����
//�EString������̕ϊ�
//�E�Z�[�u�A���[�h
//�E���͎���
//�F�X�ȃN���X�Ŏg�p������̂������Ă����ƕ֗��B
//�����̃v���W�F�N�g�Ǝ��̂��̂����Ă����Ƒ��̐l���g�����Ƃ��ł���B
//�������A���g�������Ȃ��\�������邩�炵������ƃR�����g�������A����s�����Ȃ��悤�ɂ��Ă������B